using System;

namespace SchoolProject.Domain.BusinessRule
{
    /// <summary>
    /// Represents business rule validation exception based on <see cref="Exception"/>.
    /// </summary>
    public class BusinessRuleValidationException : Exception
    {
        /// <summary>
        /// Broken rule causing the exception.
        /// </summary>
        public IBusinessRule BrokenRule { get; }

        /// <summary>
        /// Create a new instance of a class <see cref="BusinessRuleValidationException"/>.
        /// </summary>
        /// <param name="brokenRule">Broken rule causing the exception.</param>
        public BusinessRuleValidationException(IBusinessRule brokenRule)
            : base($"{brokenRule.GetType().FullName}: {brokenRule.Message}")
        {
            BrokenRule = brokenRule;
        }
    }
}
