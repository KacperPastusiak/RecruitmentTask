using MediatR;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents query handler based on <see cref="IRequestHandler{TRequest}"/>.
    /// </summary>
    /// <typeparam name="TRequest">Query type based on <see cref="IRequest"/>.</typeparam>
    /// <typeparam name="TResponse">Query response.</typeparam>
    public abstract class AQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly SchoolContext dbContext;
        protected readonly IRedisCacheService cacheService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public AQueryHandler(SchoolContext context, IRedisCacheService redisCacheService)
        {
            dbContext = context;
            cacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = getCacheKey(request);

            var result = await cacheService.Get<TResponse>(cacheKey, cancellationToken);

            if (result == null)
            {
                result = executeQuery(request);

                if (updateCacheRequired(result))
                {
                    await cacheService.Set(cacheKey, result, cancellationToken);
                }
            }

            return result;
        }

        protected abstract bool updateCacheRequired(TResponse response);

        protected abstract string getCacheKey(TRequest request);

        protected abstract TResponse executeQuery(TRequest request);
    }
}
