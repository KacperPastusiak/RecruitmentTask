using MediatR;
using SchoolProject.Common.DTO.StudentsController;

namespace SchoolProject.Infrastructure.Query
{
    /// <summary>
    /// Represents get students by language group query.
    /// </summary>
    public class GetStudentsByLanguageGroupQuery : IRequest<GetStudentsByLanguageGroupResponseDTO>
    {
        /// <summary>
        /// Class group.
        /// </summary>
        public char ClassGroup { get; private set; }

        /// <summary>
        /// Language group.
        /// </summary>
        public string LanguageGroup { get; private set; }

        /// <summary>
        /// Create a new instance of a class <see cref="GetStudentsByLanguageGroupQuery"/>.
        /// </summary>
        /// <param name="classGroup">Class group.</param>
        /// <param name="languageGroup">Language group.</param>
        public GetStudentsByLanguageGroupQuery(char classGroup, string languageGroup)
        {
            ClassGroup = classGroup;
            LanguageGroup = languageGroup;
        }
    }
}
