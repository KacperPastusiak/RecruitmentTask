using SchoolProject.Domain.DatabaseStructure;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Command
{
    /// <summary>
    /// Represetns <see cref="AddTutorCommand"/> handler.
    /// </summary>
    public class AddTutorCommandHandler : ACommandHandler<AddTutorCommand, Guid>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="AddTutorCommandHandler"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public AddTutorCommandHandler(SchoolContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        { }

        public override async Task<Guid> Handle(AddTutorCommand command, CancellationToken cancellationToken)
        {
            var schoolClass = dbContext.SchoolClasses.Where(sc => sc.ID == command.SchoolClassId).FirstOrDefault();

            var tutor = Tutor.CreateTutor(command.Name,
                                          command.LastName,
                                          schoolClass);

            await dbContext.AddAsync(tutor, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            await cacheService.Clean(RedisKeyGenerator.TutorKeyPrefix, cancellationToken);

            return tutor.ID;
        }
    }
}
