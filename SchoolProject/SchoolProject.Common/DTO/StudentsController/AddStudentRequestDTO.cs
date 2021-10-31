using SchoolProject.Common.Enums;
using System;

namespace SchoolProject.Common.DTO.StudentsController
{
    /// <summary>
    /// Represents add student request data transport object.
    /// </summary>
    public class AddStudentRequestDTO
    {
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
        /// School class identifier.
        /// </summary>
        public Guid SchoolClassId { get; set; }
    }
}
