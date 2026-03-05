using MChat.Application.Interfaces;
using MChat.Application.Services;
using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;
using MChat.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
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
            #endregion

            #region Application layer services

            builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
