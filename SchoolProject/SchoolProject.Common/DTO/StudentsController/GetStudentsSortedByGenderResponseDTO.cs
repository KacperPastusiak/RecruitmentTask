using System.Collections.Generic;

namespace SchoolProject.Common.DTO.StudentsController
{
    public class GetStudentsSortedByGenderResponseDTO : IPaging
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public List<StudentsDTO> Students { get; set; }
    }
}
