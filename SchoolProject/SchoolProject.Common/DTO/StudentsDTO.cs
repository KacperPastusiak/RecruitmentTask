using SchoolProject.Common.Enums;

namespace SchoolProject.Common.DTO
{
    public class StudentsDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public EGender Gender { get; set; }
        public string LanguageGroup { get; set; }
        public char SchoolClassGroup { get; set; }
    }
}
