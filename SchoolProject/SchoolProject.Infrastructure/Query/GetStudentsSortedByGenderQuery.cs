using MediatR;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Common.Enums;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents get students sorted by gender query.
    /// </summary>
    public class GetStudentsSortedByGenderQuery : IRequest<GetStudentsSortedByGenderResponseDTO>
    {
        /// <summary>
        /// Class group.
        /// </summary>
        public char ClassGroup { get; private set; }

        /// <summary>
        /// Sorting type.
        /// </summary>
        public ESortingType SortingType { get; private set; }

        /// <summary>
        /// Create a new instance of a class <see cref="GetStudentsSortedByGenderQuery"/>.
        /// </summary>
        /// <param name="classGroup">Class group.</param>
        /// <param name="sortingType">Sorting type.</param>
        public GetStudentsSortedByGenderQuery(char classGroup,
                                              ESortingType sortingType)
        {
            ClassGroup = classGroup;
            SortingType = sortingType;
        }
    }
}
