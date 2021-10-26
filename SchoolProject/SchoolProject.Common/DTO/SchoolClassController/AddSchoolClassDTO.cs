using System.Collections.Generic;

namespace SchoolProject.Common.DTO.SchoolClassController
{
    public class AddSchoolClassDTO
    {
        public char Group { get; set; }

        public List<string> LanguageGroups { get; set; }
    }
}
