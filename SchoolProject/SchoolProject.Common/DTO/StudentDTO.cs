using SchoolProject.Common.Enums;
using System;

namespace SchoolProject.Common.DTO
{
    /// <summary>
    /// Represents student data transport object.
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// Stident identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Student last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Student gender.
        /// </summary>
        public EGender Gender { get; set; }

        /// <summary>
        /// Student language group.
        /// </summary>
        public string LanguageGroup { get; set; }

        /// <summary>
        /// School class group
        /// </summary>
        public char SchoolClassGroup { get; set; }

        /// <summary>
        /// School class identifier.
        /// </summary>
        public Guid SchoolClassIdentifier { get; set; }
    }
}
