
using Banjo_kazooie_api.Models;
using Banjo_kazooie_api.Services;
using Banjo_kazooie_api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Banjo_kazooie_api
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "all", builder =>
                {
                    builder.WithOrigins("*").AllowAnyMethod();
                });
            });

            services.AddControllers();

            services.Configure<FilePaths>(Configuration.GetSection("FilePaths"));

            services.AddTransient<IAbilitiesService, AbilitiesService>();
            services.AddTransient<IAreasService, AreasService>();
            services.AddTransient<ICharactersService, CharactersService>();
            services.AddTransient<ICollectablesService, CollectablesService>();
            services.AddTransient<IEnemiesService, EnemiesService>();
            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<ILevelsService, LevelsService>();
            services.AddTransient<IMiniGamesService, MiniGamesService>();
            services.AddTransient<ITransformationsService, TransformationsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Commented out due to being unneeded thanks to NGINX
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("all");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
