using MediatR;
using SchoolProject.Common.DTO;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Common.Enums;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Query
{
    public class GetStudentsSortedByGendetQueryHandler : IRequestHandler<GetStudentsSortedByGenderQuery, GetStudentsSortedByGenderResponseDTO>
    {
        private readonly SchoolContext dbContext;
        private readonly IRedisCacheService cacheService;

        public GetStudentsSortedByGendetQueryHandler(SchoolContext context, IRedisCacheService redisCacheService)
        {
            dbContext = context;
            cacheService = redisCacheService;
        }

        public async Task<GetStudentsSortedByGenderResponseDTO> Handle(GetStudentsSortedByGenderQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = combineCahceKey(request);

            var result = await cacheService.Get<GetStudentsSortedByGenderResponseDTO>(cacheKey);

            if (result == null)
            {
                result = new GetStudentsSortedByGenderResponseDTO()
                {
                    Page = request.Page,
                    Limit = request.Limit,
                    Students = new List<StudentsDTO>()
                };
                var startPosition = request.Page * request.Limit;

                var students = getStudents(request.SortingType, request.ClassGroup, startPosition, request.Limit);

                if (students != null &&
                    students.Count > 0)
                {
                    result.Students = students;

                    await cacheService.Set(cacheKey, result);
                }
            }

            return result;
        }

        private List<StudentsDTO> getStudents(ESortingType sortingType, char classGroup, int startPosition, int limit)
        {
            switch (sortingType)
            {
                case ESortingType.Ascending:
                    {
                        return dbContext.Students.Where(s => s.SchoolClass.Group == classGroup)
                                                 .OrderBy(s => s.Gender)
                                                 .Skip(startPosition)
                                                 .Take(limit)
                                                 .Select(s => new StudentsDTO
                                                 {
                                                     Name = s.Name,
                                                     LastName = s.LastName,
                                                     Gender = s.Gender,
                                                     LanguageGroup = s.LanguageGroup,
                                                     SchoolClassGroup = s.SchoolClass.Group
                                                 })
                                                 .ToList();
                    }
                case ESortingType.Descending:
                    {
                        return dbContext.Students.Where(s => s.SchoolClass.Group == classGroup)
                                                 .OrderByDescending(s => s.Gender)
                                                 .Skip(startPosition)
                                                 .Take(limit)
                                                 .Select(s => new StudentsDTO
                                                 {
                                                     Name = s.Name,
                                                     LastName = s.LastName,
                                                     Gender = s.Gender,
                                                     LanguageGroup = s.LanguageGroup,
                                                     SchoolClassGroup = s.SchoolClass.Group
                                                 })
                                                 .ToList();
                    }
                default:
                    {
                        return new List<StudentsDTO>();
                    }
            }
        }

        private string combineCahceKey(GetStudentsSortedByGenderQuery request)
        {
            return $"{request.ClassGroup}{request.SortingType}{request.Page}{request.SortingType}";
        }
    }
}
