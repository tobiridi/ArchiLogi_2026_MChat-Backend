using MChat.Application.Interfaces;
using MChat.Application.Services;
using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;
using MChat.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            //app.UseCors((config) =>
            //{
            //    if(app.Environment.IsDevelopment())
            //    {
            //        config.AllowCredentials()
            //        .AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .Build();
            //    }
            //    else if(app.Environment.IsProduction())
            //    {
            //        config.WithOrigins("")
            //        .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
            //        .WithHeaders("")
            //        .AllowCredentials()
            //        .Build();
            //    }

            //});

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsPolicyName1);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
