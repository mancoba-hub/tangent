using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Liso.Tangent.Api
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
            services.AddControllers();
            services.AddDbContext<TangentContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TangentDB"));
            });
            ConfigureSwagger(services);
            services.AddHealthChecks();

            services.AddTransient<IRestHelper, RestHelper>();
            services.AddTransient<ISuperheroService, SuperheroService>();
            services.AddTransient<IFavouriteRepository, FavouriteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TangentContext tangentContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Liso Mbiza - Tangent Superhero Assessement"));
            }

            tangentContext.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHealthChecks("/health");
        }

        /// <summary>
        /// Configures the swagger
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Liso Mbiza - Tangent Superhero Assessement", Version = "v1" });
            });
        }
    }
}
