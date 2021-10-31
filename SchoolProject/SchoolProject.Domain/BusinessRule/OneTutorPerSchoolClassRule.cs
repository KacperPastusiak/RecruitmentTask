using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class OneTutorPerSchoolClassRule : IBusinessRule
    {
        private readonly Guid schoolClassTutorId;

        public OneTutorPerSchoolClassRule(Guid schoolClassTutorId)
        {
            this.schoolClassTutorId = schoolClassTutorId;
        }

        public bool IsBroken()
        {
            return schoolClassTutorId != Guid.Empty;
        }

        public string Message => $"School class may have only one tutor. Assigned tutor identifier: {schoolClassTutorId}";
    }
}
