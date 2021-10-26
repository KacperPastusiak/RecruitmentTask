namespace SchoolProject.Common.DTO
{
    /// <summary>
    /// Represents paging interface.
    /// </summary>
    public interface IPaging
    {
        /// <summary>
        /// Requested page.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Requested elements per page.
        /// </summary>
        int Limit { get; set; }
    }
}
