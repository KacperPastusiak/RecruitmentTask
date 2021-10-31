using SchoolProject.Common.DTO;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Common.Enums;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System.Linq;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents <see cref="GetStudentsSortedByGenderQuery"/> handler.
    /// </summary>
    public class GetStudentsSortedByGendetQueryHandler : AQueryHandler<GetStudentsSortedByGenderQuery, GetStudentsSortedByGenderResponseDTO>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="GetStudentsSortedByGendetQueryHandler"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public GetStudentsSortedByGendetQueryHandler(SchoolContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        { }

        protected override bool updateCacheRequired(GetStudentsSortedByGenderResponseDTO response)
        {
            return response?.Students != null;
        }

        protected override string getCacheKey(GetStudentsSortedByGenderQuery request)
        {
            return RedisKeyGenerator.GenerateStudentsKey(request.ClassGroup, request.SortingType);
        }

        protected override GetStudentsSortedByGenderResponseDTO executeQuery(GetStudentsSortedByGenderQuery request)
        {
            return new GetStudentsSortedByGenderResponseDTO()
            {
                Students = getStudents(request.SortingType, request.ClassGroup)
            };
        }

        private StudentDTO[] getStudents(ESortingType sortingType, char classGroup)
        {
            StudentDTO[] result;

            switch (sortingType)
            {
                case ESortingType.Ascending:
                    {
                        result = dbContext.Students.Where(s => s.SchoolClass.Group == classGroup)
                                                   ?.OrderBy(s => s.Gender)
                                                   ?.Select(s => new StudentDTO
                                                   {
                                                       Id = s.ID,
                                                       Name = s.Name,
                                                       LastName = s.LastName,
                                                       Gender = s.Gender,
                                                       LanguageGroup = s.LanguageGroup,
                                                       SchoolClassGroup = s.SchoolClass.Group,
                                                       SchoolClassIdentifier = s.SchoolClass.ID
                                                   })
                                                   ?.ToArray();

                        break;
                    }
                case ESortingType.Descending:
                    {
                        result = dbContext.Students.Where(s => s.SchoolClass.Group == classGroup)
                                                   ?.OrderByDescending(s => s.Gender)
                                                   ?.Select(s => new StudentDTO
                                                   {
                                                       Id = s.ID,
                                                       Name = s.Name,
                                                       LastName = s.LastName,
                                                       Gender = s.Gender,
                                                       LanguageGroup = s.LanguageGroup,
                                                       SchoolClassGroup = s.SchoolClass.Group,
                                                       SchoolClassIdentifier = s.SchoolClass.ID
                                                   })
                                                   ?.ToArray();

                        break;
                    }
                default:
                    {
                        result = new StudentDTO[0];

                        break;
                    }
            }

            return result ?? new StudentDTO[0];
        }
    }
}
