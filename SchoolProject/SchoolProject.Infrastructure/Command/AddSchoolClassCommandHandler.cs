using MediatR;
using SchoolProject.Domain.DatabaseStructure;
using SchoolProject.Infrastructure.Database;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Command
{
    public class AddSchoolClassCommandHandler : IRequestHandler<AddSchoolClassCommand, Guid>
    {
        private readonly SchoolContext dbContext;

        public AddSchoolClassCommandHandler(SchoolContext context)
        {
            dbContext = context;
        }

        public async Task<Guid> Handle(AddSchoolClassCommand command, CancellationToken token)
        {
            var sClass = SchoolClass.CreateSchoolClass(command.Group, command.LanguageGroups);

            await dbContext.AddAsync(sClass);

            await dbContext.SaveChangesAsync();

            return sClass.ID;
        }
    }
}
