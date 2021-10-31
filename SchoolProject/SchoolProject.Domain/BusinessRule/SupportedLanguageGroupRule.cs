using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class SupportedLanguageGroupRule : IBusinessRule
    {
        private static readonly List<string> languageList = new List<string>
        {
            "EN",
            "PL",
            "FR",
            "RU"
        };

        private readonly string language;

        public SupportedLanguageGroupRule(string language)
        {
            this.language = language;
        }

        public bool IsBroken()
        {
            return !languageList.Contains(language);
        }

        public string Message => $"Class language {language} is not supported. Supported language: {getSupportedLanguages()}";

        private string getSupportedLanguages()
        {
            string result = string.Empty;

            foreach (var language in languageList)
            {
                if (string.IsNullOrWhiteSpace(result))
                    result = language;
                else
                    result += $", {language}";
            }

            return result;
        }
    }
}
