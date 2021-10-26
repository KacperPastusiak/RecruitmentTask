using System.Collections.Generic;

namespace SchoolProject.Domain.BusinessRule
{
    public class TwoLanguageGroupPerSchoolClassRule : IBusinessRule
    {
        private readonly List<string> languageGroups;

        public TwoLanguageGroupPerSchoolClassRule(List<string> languageGroups)
        {
            this.languageGroups = languageGroups;
        }

        public bool IsBroken()
        {
            return languageGroups.Count > 2;
        }

        public string Message => "Class cannot have more than 2 language groups.";
    }
}
