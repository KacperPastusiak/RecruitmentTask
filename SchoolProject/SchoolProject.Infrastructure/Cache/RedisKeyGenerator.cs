using SchoolProject.Common.Enums;

namespace SchoolProject.Infrastructure.Cache
{
    internal static class RedisKeyGenerator
    {
        public static string StudentsKeyPrefix { get { return "Students"; } }
        public static string SchoolClassKeyPrefix { get { return "Class"; } }
        public static string TutorKeyPrefix { get { return "Tutor"; } }

        public static string GenerateStudentsKey(char classGroup, ESortingType sortingType)
        {
            return $"{StudentsKeyPrefix}-ClassGroup:{classGroup}-SortingType:{sortingType}";
        }

        public static string GenerateStudentsKey(char classGroup, string languageGroup)
        {
            return $"{StudentsKeyPrefix}-ClassGroup:{classGroup}-LanguageGroup:{languageGroup}";
        }

        public static string GenerateTutorKey()
        {
            return $"{TutorKeyPrefix}";
        }
    }
}
