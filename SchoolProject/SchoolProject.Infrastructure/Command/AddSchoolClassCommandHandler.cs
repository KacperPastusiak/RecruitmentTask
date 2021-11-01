using SchoolProject.Domain.DatabaseStructure;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Command
{
    /// <summary>
    /// Represetns <see cref="AddSchoolClassCommand"/> handler.
    /// </summary>
    public class AddSchoolClassCommandHandler : ACommandHandler<AddSchoolClassCommand, Guid>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="AddSchoolClassCommandHandler"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public AddSchoolClassCommandHandler(SchoolContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        { }

        public override async Task<Guid> Handle(AddSchoolClassCommand command, CancellationToken cancellationToken)
        {
            var sClass = SchoolClass.CreateSchoolClass(command.Group, command.LanguageGroups);

            try
            {
                await dbContext.AddAsync(sClass, cancellationToken);

                await dbContext.SaveChangesAsync(cancellationToken);

                await cacheService.Clean(RedisKeyGenerator.StudentsKeyPrefix, cancellationToken);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;

                throw ex;
            }

            return sClass.ID;
        }
    }
}
