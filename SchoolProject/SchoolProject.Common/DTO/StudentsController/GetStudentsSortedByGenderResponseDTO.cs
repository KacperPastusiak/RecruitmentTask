namespace SchoolProject.Common.DTO.StudentsController
{
    /// <summary>
    /// Represents get students sorted by gender response data transport object.
    /// </summary>
    public class GetStudentsSortedByGenderResponseDTO
    {
        /// <summary>
        /// List of students.
        /// </summary>
        public StudentDTO[] Students { get; set; }
    }
}
