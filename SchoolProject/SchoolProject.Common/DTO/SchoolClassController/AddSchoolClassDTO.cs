using System.Collections.Generic;

namespace SchoolProject.Common.DTO.SchoolClassController
{
    /// <summary>
    /// Represents add school class data transposrt object.
    /// </summary>
    public class AddSchoolClassDTO
    {
        /// <summary>
        /// School class group.
        /// </summary>
        public char Group { get; set; }

        /// <summary>
        /// List of language groups for school class..
        /// </summary>
        public List<string> LanguageGroups { get; set; }
    }
}
