using System;

namespace SchoolProject.Common.DTO
{
    /// <summary>
    /// Represents tutor data transport object.
    /// </summary>
    public class TutorDTO
    {
        /// <summary>
        /// Tutor identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tutor name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tutor last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// School class group.
        /// </summary>
        public char SchoolClassGroup { get; set; }

        /// <summary>
        /// School class identifier.
        /// </summary>
        public Guid SchoolClassId { get; set; }
    }
}
