using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.ControllersFilters;
using SchoolProject.Common.DTO.StudentsController;
using SchoolProject.Infrastructure.Query;
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

        [HttpGet("GetSortedByGender")]
        public async Task<ActionResult<GetStudentsSortedByGenderResponseDTO>> GetStudentsSortedByGender(GetStudentsSortedByGenderRequestDTO request)
        {
            var response = await mediator.Send(new GetStudentsSortedByGenderQuery(request.ClassGroup,
                                                                                  request.SortingType,
                                                                                  request.Page,
                                                                                  request.Limit));

            return response;
        }
    }
}
