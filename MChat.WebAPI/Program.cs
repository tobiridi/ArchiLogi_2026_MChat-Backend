using MChat.Application.Interfaces;
using MChat.Application.Services;
using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;
using MChat.Infrastructure.Repositories;
using MChat.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Threading.RateLimiting;

namespace MChat.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options => {
                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                if (connectionString is null)
                    throw new InvalidOperationException($"DefaultConnection not found {nameof(connectionString)}");

                options.UseSqlServer(connectionString);
            });

            #region Rate limiter configuration

            builder.Services.AddRateLimiter(options =>
            {
                // global
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 100,
                            Window = TimeSpan.FromMinutes(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        }));

                // specific
                options.AddFixedWindowLimiter("Authentication", winOpt =>
                {
                    winOpt.PermitLimit = 10;
                    winOpt.Window = TimeSpan.FromSeconds(10);
                    winOpt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    winOpt.QueueLimit = 0;
                });

                options.OnRejected = async (context, cancellationToken) =>
                {
                    // Custom rejection handling logic
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.HttpContext.Response.Headers.RetryAfter = "60";

                    await context.HttpContext.Response.WriteAsync("Rate limit exceeded. Please try again later.", cancellationToken);
                };
            });
            #endregion

            #region Repositories services

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            #endregion

            #region Application layer services

            builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            #endregion

            #region CORS configuration

            string corsPolicyName1 = "MChat_default";

            builder.Services.AddCors((options) => {

                options.AddPolicy(corsPolicyName1, policy =>
                {
                    policy.WithOrigins("https://localhost:7008")
                    .WithMethods("GET", "POST", "PUT", "PATCH", "DELTE")
                    .AllowAnyHeader();
                });
            });
            #endregion

            #region Cookie configuration (not configured)

            //builder.Services.AddCookiePolicy(options => 
            //{
            //    options.HttpOnly = HttpOnlyPolicy.Always;
            //    options.Secure = CookieSecurePolicy.SameAsRequest;

            //});
            #endregion

            #region JWT configuration

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtOptions =>
                {
                    IConfigurationSection jwt = configuration.GetSection("jwt");

                    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt.GetValue<string>("Issuer"),
                        ValidateAudience = true,
                        ValidAudience = jwt.GetValue<string>("Audience"),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.GetValue<string>("secretKey")!)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)
                    };
                });

            #endregion

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mchat web API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT token"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[] {}
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsPolicyName1);
            app.UseRateLimiter();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
