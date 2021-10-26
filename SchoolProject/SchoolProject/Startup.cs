using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.API.Configuration;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;

namespace SchoolProject
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerDocumentation();

            services.AddSingleton<IRedisCacheService, RedisCacheService>();

            var connectionString = configuration["DbConnectionString"];
            services.AddDbContext<SchoolContext>(options =>
                    options.UseNpgsql(connectionString));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = $"{configuration.GetValue<string>("RedisCache:Host")}:{configuration.GetValue<int>("RedisCache:Port")}";
            });

            services.ConfigureMediatR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwaggerDocumentation();
        }
    }
}
