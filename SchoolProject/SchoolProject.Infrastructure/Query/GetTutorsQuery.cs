using MediatR;
using SchoolProject.Common.DTO.TutorController;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents get tutor query.
    /// </summary>
    public class GetTutorsQuery : IRequest<GetTutorsResponseDTO>
    {
        /// <summary>
        /// Create a new instance of a class <see cref="GetTutorsQuery"/>.
        /// </summary>
        public GetTutorsQuery() { }
    }
}
