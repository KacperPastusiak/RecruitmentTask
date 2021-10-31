using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class AtLeastOneLanguageGroupRule : IBusinessRule
    {
        private readonly List<string> languageGroups;

        public AtLeastOneLanguageGroupRule(List<string> languageGroups)
        {
            this.languageGroups = languageGroups;
        }

        public bool IsBroken()
        {
            if (languageGroups == null)
                return true;

            return languageGroups.Count == 0;
        }

        public string Message => "Class must have at least one language group.";
    }
}
