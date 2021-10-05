using DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Modern.BisnessAccessLayer.IRepository;
using Modern.BisnessAccessLayer.Repository;
using Modern.DataAccessLayer.IRepository;
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
            services.AddDbContext<ModernDataContext>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IAesOperation, AesOperation>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddScoped<IGameBusinessLogic, GameBusinessLogic>();

            //Unit of work implimentation
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IKeyRepository, KeyRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
