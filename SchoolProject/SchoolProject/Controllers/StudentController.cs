using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.ControllersFilters;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Infrastructure.Command;
using SchoolProject.Infrastructure.Query;
using System;
using System.Threading.Tasks;

namespace SchoolProject.API.Controllers
{
    [Route("api/student")]
    [TypeFilter(typeof(ExceptionFilter))]
    public class StudentController : Controller
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Guid>> AddStudent([FromBody] AddStudentRequestDTO request)
        {
            var response = await mediator.Send(new AddStudentCommand(request.Name,
                                                                     request.LastName,
                                                                     request.Gender,
                                                                     request.LanguageGroup,
                                                                     request.SchoolClassId));

            return response;
        }

        [HttpGet("GetSortedByGender")]
        public async Task<ActionResult<GetStudentsSortedByGenderResponseDTO>> GetStudentsSortedByGender([FromBody] GetStudentsSortedByGenderRequestDTO request)
        {
            var response = await mediator.Send(new GetStudentsSortedByGenderQuery(request.ClassGroup, request.SortingType));

            return response;
        }

        [HttpGet("GetByLanguageGroup")]
        public async Task<ActionResult<GetStudentsByLanguageGroupResponseDTO>> GetStudentsByLanguageGroup([FromBody] GetStudentsByLanguageGroupRequestDTO request)
        {
            var response = await mediator.Send(new GetStudentsByLanguageGroupQuery(request.ClassGroup, request.LanguageClass));

            return response;
        }
    }
}
