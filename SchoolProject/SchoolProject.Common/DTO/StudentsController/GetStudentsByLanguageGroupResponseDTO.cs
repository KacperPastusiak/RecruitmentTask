namespace SchoolProject.Common.DTO.StudentsController
{
    /// <summary>
    /// Represents get students by language group response data transport object.
    /// </summary>
    public class GetStudentsByLanguageGroupResponseDTO
    {
        /// <summary>
        /// List of students.
        /// </summary>
        public StudentDTO[] Students { get; set; }
    }
}
