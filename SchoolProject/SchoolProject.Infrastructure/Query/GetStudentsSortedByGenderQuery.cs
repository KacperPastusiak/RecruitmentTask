using MediatR;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Common.Enums;

namespace SchoolProject.Infrastructure.Query
{
    public class GetStudentsSortedByGenderQuery : IRequest<GetStudentsSortedByGenderResponseDTO>
    {
        public char ClassGroup { get; set; }

        public ESortingType SortingType { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }

        public GetStudentsSortedByGenderQuery(char classGroup,
                                              ESortingType sortingType,
                                              int page,
                                              int limit)
        {
            ClassGroup = classGroup;
            SortingType = sortingType;
            Page = page;
            Limit = limit;
        }
    }
}
