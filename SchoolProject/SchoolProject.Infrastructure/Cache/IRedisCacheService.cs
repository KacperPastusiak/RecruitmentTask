using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Cache
{
    public interface IRedisCacheService
    {
        Task<T> Get<T>(string key);
        Task<T> Set<T>(string key, T value);
    }
}
