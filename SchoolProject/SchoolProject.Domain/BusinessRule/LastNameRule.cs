using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class LastNameRule : IBusinessRule
    {
        private readonly string name;

        public LastNameRule(string name)
        {
            this.name = name;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(name);
        }

        public string Message => "Last name cannot be empty.";
    }
}
