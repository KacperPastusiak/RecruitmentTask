using MediatR;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Command
{
    /// <summary>
    /// Represents command handler based on <see cref="IRequestHandler{TRequest}"/>.
    /// </summary>
    /// <typeparam name="TRequest">Command type based on <see cref="IRequest"/>.</typeparam>
    /// <typeparam name="TResponse">Copmmand response.</typeparam>
    public abstract class ACommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly SchoolContext dbContext;
        protected readonly IRedisCacheService cacheService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public ACommandHandler(SchoolContext context, IRedisCacheService redisCacheService)
        {
            dbContext = context;
            cacheService = redisCacheService;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
