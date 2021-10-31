using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.API.Configuration;
using SchoolProject.Infrastructure.Database;

namespace SchoolProject
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerDocumentation();

            services.AddDbContext<SchoolContext>(
                options => options.UseNpgsql(configuration.GetValue<string>("DbConnectionString")));

            services.ConfigureRedis(configuration);

            services.ConfigureMediatR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwaggerDocumentation();

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            {
                var context = serviceScope.ServiceProvider.GetService<SchoolContext>();
                context.Database.Migrate();
            }
        }
    }
}
