using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class StudentLanguageGroupRule : IBusinessRule
    {
        private readonly List<string> languageGroups;
        private readonly string languageGroup;

        public StudentLanguageGroupRule(string languageGroup, List<string> languageGroups)
        {
            this.languageGroup = languageGroup;
            this.languageGroups = languageGroups;
        }

        public bool IsBroken()
        {
            if (languageGroups == null)
                return true;

            return !languageGroups.Contains(languageGroup);
        }

        public string Message => "Student may only belong to the language groups of the class.";
    }
}
