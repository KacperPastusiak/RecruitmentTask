using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class TwoLanguageGroupPerSchoolClassRule : IBusinessRule
    {
        private readonly List<string> languageGroups;

        public TwoLanguageGroupPerSchoolClassRule(List<string> languageGroups)
        {
            this.languageGroups = languageGroups;
        }

        public bool IsBroken()
        {
            if (languageGroups == null)
                return true;

            return languageGroups.Count > 2;
        }

        public string Message => "Class cannot have more than 2 language groups.";
    }
}
