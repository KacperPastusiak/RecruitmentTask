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
    /// Represetns <see cref="AddStudentCommand"/> handler.
    /// </summary>
    public class AddStudentCommandHandler : ACommandHandler<AddStudentCommand, Guid>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="AddStudentCommandHandler"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public AddStudentCommandHandler(SchoolContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        { }

        public override async Task<Guid> Handle(AddStudentCommand command, CancellationToken cancellationToken)
        {
            var schoolClass = dbContext.SchoolClasses.FirstOrDefault(sc => sc.ID == command.SchoolClassId);

            var student = Student.CreateStudent(command.Name,
                                                command.LastName,
                                                command.Gender,
                                                command.LanguageGroup,
                                                schoolClass);

            await dbContext.AddAsync(student, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            await cacheService.Clean(RedisKeyGenerator.SchoolClassKeyPrefix, cancellationToken);

            return student.ID;
        }
    }
}
