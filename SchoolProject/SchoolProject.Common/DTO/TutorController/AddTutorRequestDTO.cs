using System;

namespace SchoolProject.Common.DTO.TutorController
{
    /// <summary>
    /// Represents add tutor request data transport object.
    /// </summary>
    public class AddTutorRequestDTO
    {
        /// <summary>
        /// Tutor name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tutor last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// School class identifier.
        /// </summary>
        public Guid SchoolClassId { get; set; }
    }
}
