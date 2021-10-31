namespace SchoolProject.Common.DTO.TutorController
{
    /// <summary>
    /// Represents get tutor response data transport object.
    /// </summary>
    public class GetTutorsResponseDTO
    {
        /// <summary>
        /// List of tutors.
        /// </summary>
        public TutorDTO[] Tutors { get; set; }
    }
}
