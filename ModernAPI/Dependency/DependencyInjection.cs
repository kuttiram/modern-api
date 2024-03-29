﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modern.BisnessAccessLayer.IRepository;
using Modern.BisnessAccessLayer.Repository;
using Modern.DataAccessLayer.IRepository;
using Modern.DataAccessLayer.Models;
using Modern.DataAccessLayer.Repository;
using Modern.DataAccessLayer.UOW;
using Modern.Utility.ISecurity;
using Modern.Utility.Security;

namespace ModernAPI.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<Modern_DataContext>(options => options.UseSqlServer(Startup.StaticConfig.GetConnectionString("dbConnection")));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IAesOperation, AesOperation>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddScoped<IGameBusinessLogic, GameBusinessLogic>();
            services.AddScoped<IHomeBusinessLogic, HomeBusinessLogic>();

            //Unit of work implimentation
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IKeyRepository, KeyRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
