using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SchoolProject.Test")]
namespace SchoolProject.Domain.BusinessRule
{
    internal class NameRule : IBusinessRule
    {
        private readonly string name;

        public NameRule(string name)
        {
            this.name = name;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(name);
        }

        public string Message => "Name cannot be empty.";
    }
}
