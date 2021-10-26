namespace SchoolProject.Domain.BusinessRule
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
