namespace SchoolProject.Common.DTO.StudentsController
{
    /// <summary>
    /// Represents get students by language group request data transport object.
    /// </summary>
    public class GetStudentsByLanguageGroupRequestDTO
    {
        /// <summary>
        /// Student class group.
        /// </summary>
        public char ClassGroup { get; set; }

        /// <summary>
        /// Student language group.
        /// </summary>
        public string LanguageClass { get; set; }
    }
}
