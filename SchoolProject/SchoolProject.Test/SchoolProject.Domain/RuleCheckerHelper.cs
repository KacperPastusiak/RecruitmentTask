using SchoolProject.Domain.BusinessRule;
using System;

namespace SchoolProject.Test.SchoolProject.Domain
{
    internal static class RuleCheckerHelper
    {
        public static bool CheckBusinessRuleException(Action action, Type ruleType)
        {
            try
            {
                action.Invoke();
                return false;
            }
            catch (BusinessRuleValidationException ex)
            {
                return ex.BrokenRule.GetType() == ruleType;
            }
            catch
            {
                return false;
            }
        }
    }
}
