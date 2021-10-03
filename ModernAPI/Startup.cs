using DadaAccessLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Modern.BisnessAccessLayer.IRepository;
using Modern.BisnessAccessLayer.Repository;
using Modern.DadaAccessLayer.IRepository;
using Modern.DadaAccessLayer.Repository;
using Modern.Object.Models;
using Modern.Utility.ISecurity;
using Modern.Utility.Security;
using System;
using System.Text;

namespace ModernAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddCors();
            services.AddControllers();

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            //Automapper Initilize
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // or we can user typeof(ModernMapper)

            //I don't want refer dataaccesslya in api
            //services.AddDbContext<ModernDataContext>(options => options.UseSqlServer("Server=DESKTOP-GV4424J;Database=TestDB;Trusted_Connection=True;"));

            // configure DI for application services
            services.AddDbContext<ModernDataContext>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IAesOperation, AesOperation>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddScoped<IGameBusinessLogic, GameBusinessLogic>();

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration.GetSection("AppSettings")["JwtIssuer"],
                        ValidAudience = Configuration.GetSection("AppSettings")["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings")["Secret"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            //app.UseAuthentication();
            // custom jwt auth middleware
            //app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Modern Api v1");
            });

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
