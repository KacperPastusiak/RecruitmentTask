using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Cache;

namespace SchoolProject.API.Configuration
{
    internal static class RedisExtensions
    {
        internal static IServiceCollection ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("RedisCacheConnectionString");

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
            });

            return services;
        }
    }
}
