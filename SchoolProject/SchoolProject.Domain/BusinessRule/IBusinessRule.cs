namespace SchoolProject.Domain.BusinessRule
{
    /// <summary>
    /// Represents busisess role interface.
    /// </summary>
    public interface IBusinessRule
    {
        /// <summary>
        /// Check if rule is broken.
        /// </summary>
        /// <returns><see langword="true"/> if rule is broken, otherwise <see langword="false"/>.</returns>
        bool IsBroken();

        /// <summary>
        /// Broken rule message.
        /// </summary>
        string Message { get; }
    }
}
