using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Cache
{
    /// <summary>
    /// Represents redis cache service interface.
    /// </summary>
    public interface IRedisCacheService
    {
        /// <summary>
        /// Get value from cache using specific key.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="key">Key.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        Task<T> Get<T>(string key, CancellationToken cancellationToken);

        /// <summary>
        /// Set value to cache for specific key.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="key">Key.</param>
        /// <param name="value">Value to save in cache.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        Task<T> Set<T>(string key, T value, CancellationToken cancellationToken);

        /// <summary>
        /// Clean cache for specific key pattern.
        /// </summary>
        /// <param name="keyPrefix">Key prefix pattern.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        Task<bool> Clean(string keyPrefix, CancellationToken cancellationToken);
    }
}
