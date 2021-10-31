using SchoolProject.Common.DTO;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System.Linq;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents <see cref="GetStudentsByLanguageGroupQuery"/> handler.
    /// </summary>
    public class GetStudentsByLanguageGroupQueryHandler : AQueryHandler<GetStudentsByLanguageGroupQuery, GetStudentsByLanguageGroupResponseDTO>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="GetStudentsByLanguageGroupQueryHandler"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public GetStudentsByLanguageGroupQueryHandler(SchoolContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        { }

        protected override bool updateCacheRequired(GetStudentsByLanguageGroupResponseDTO response)
        {
            return response?.Students != null;
        }

        protected override string getCacheKey(GetStudentsByLanguageGroupQuery request)
        {
            return RedisKeyGenerator.GenerateStudentsKey(request.ClassGroup, request.LanguageGroup);
        }

        protected override GetStudentsByLanguageGroupResponseDTO executeQuery(GetStudentsByLanguageGroupQuery request)
        {
            return new GetStudentsByLanguageGroupResponseDTO()
            {
                Students = getStudents(request)
            };
        }

        private StudentDTO[] getStudents(GetStudentsByLanguageGroupQuery request)
        {
            return dbContext.Students.Where(s => s.SchoolClass.Group == request.ClassGroup &&
                                                 s.LanguageGroup == request.LanguageGroup)
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
        }
    }
}
