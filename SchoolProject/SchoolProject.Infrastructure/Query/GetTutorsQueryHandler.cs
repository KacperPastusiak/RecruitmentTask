using SchoolProject.Common.DTO;
using SchoolProject.Common.DTO.TutorController;
using SchoolProject.Infrastructure.Cache;
using SchoolProject.Infrastructure.Database;
using System.Linq;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents <see cref="GetTutorsQuery"/> handler.
    /// </summary>
    public class GetTutorsQueryHandler : AQueryHandler<GetTutorsQuery, GetTutorsResponseDTO>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="GetTutorsQueryHandler"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="redisCacheService">Redis cache service.</param>
        public GetTutorsQueryHandler(SchoolContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        { }

        protected override bool updateCacheRequired(GetTutorsResponseDTO response)
        {
            return response?.Tutors != null;
        }

        protected override string getCacheKey(GetTutorsQuery request)
        {
            return RedisKeyGenerator.GenerateTutorKey();
        }

        protected override GetTutorsResponseDTO executeQuery(GetTutorsQuery request)
        {
            return new GetTutorsResponseDTO
            {
                Tutors = getTutors(request)
            };
        }

        private TutorDTO[] getTutors(GetTutorsQuery request)
        {
            return dbContext.Tutors.Select(t => new TutorDTO()
            {
                Id = t.ID,
                Name = t.Name,
                LastName = t.LastName,
                SchoolClassGroup = t.SchoolClass.Group,
                SchoolClassId = t.SchoolClassId
            }).ToArray();
        }
    }
}
