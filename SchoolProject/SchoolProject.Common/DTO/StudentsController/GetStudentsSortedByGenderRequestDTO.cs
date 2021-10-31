using SchoolProject.Common.Enums;

namespace SchoolProject.Common.DTO.StudentsController
{
    /// <summary>
    /// Represents get students by gender request data transport object.
    /// </summary>
    public class GetStudentsSortedByGenderRequestDTO
    {
        /// <summary>
        /// School class group.
        /// </summary>
        public char ClassGroup { get; set; }

        /// <summary>
        /// Sorting type.
        /// </summary>
        public ESortingType SortingType { get; set; }
    }
}
