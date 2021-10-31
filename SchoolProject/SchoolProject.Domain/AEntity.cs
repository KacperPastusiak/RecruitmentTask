using SchoolProject.Domain.BusinessRule;

namespace SchoolProject.Domain
{
    /// <summary>
    /// Represents base entity class.
    /// </summary>
    public abstract class AEntity
    {
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
