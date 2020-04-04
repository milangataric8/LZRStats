using AutoMapper;
using LZRStatsApi.Attributes;
using LZRStatsApi.Data;
using LZRStatsApi.Helpers;
using LZRStatsApi.Importers;
using LZRStatsApi.Repositories;
using LZRStatsApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace LZRStatsApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                              .WithOrigins("http://localhost:4200/")
            .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<LzrStatsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LZRStatsContext")));
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            RegisterServices(services);

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeamGameRepository, TeamGameRepository>();
            services.AddScoped<IStatsImporter, StatsImporter>();
            services.AddScoped<ValidateFileAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // global cors policy
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
            //    RequestPath = new PathString("/Resources")
            //});
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
