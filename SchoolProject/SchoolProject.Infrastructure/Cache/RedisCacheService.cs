using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Cache
{
    /// <summary>
    /// Represents redis cache service.
    /// </summary>
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache cache;
        private readonly ConnectionMultiplexer connectionMultiplexer;

        /// <summary>
        /// Create a new instance of a class <see cref="RedisCacheService"/>.
        /// </summary>
        /// <param name="cache">Distributed cache of serialized value.</param>
        /// <param name="configuration">Application configuration.</param>
        public RedisCacheService(IDistributedCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            connectionMultiplexer = ConnectionMultiplexer.Connect(configuration["RedisCacheConnectionString"]);
        }

        public async Task<T> Get<T>(string key, CancellationToken cancellationToken)
        {
            var value = await cache.GetStringAsync(key, cancellationToken);

            if (value != null)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }

        public async Task<T> Set<T>(string key, T value, CancellationToken cancellationToken)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            await cache.SetStringAsync(key, JsonConvert.SerializeObject(value), timeOut, cancellationToken);

            return value;
        }

        public async Task<bool> Clean(string keyPrefix, CancellationToken cancellationToken)
        {
            foreach (var ep in connectionMultiplexer.GetEndPoints())
            {
                var server = connectionMultiplexer.GetServer(ep);
                var keys = server.Keys(pattern: keyPrefix + "*").ToArray();

                foreach (var key in keys)
                {
                    await cache.RemoveAsync(key, cancellationToken);
                }
            }

            return true;
        }
    }
}
