using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.ControllersFilters;
using SchoolProject.Common.DTO.TutorController;
using SchoolProject.Infrastructure.Command;
using SchoolProject.Infrastructure.Query;
using System;
using System.Threading.Tasks;

namespace SchoolProject.API.Controllers
{
    [Route("api/tutor")]
    [TypeFilter(typeof(ExceptionFilter))]
    public class TutorController : Controller
    {
        private readonly IMediator mediator;

        public TutorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Guid>> AddTutor([FromBody] AddTutorRequestDTO request)
        {
            var response = await mediator.Send(new AddTutorCommand(request.Name, request.LastName, request.SchoolClassId));

            return response;
        }

        [HttpGet("GetTutors")]
        public async Task<ActionResult<GetTutorsResponseDTO>> GetTutors()
        {
            var response = await mediator.Send(new GetTutorsQuery());

            return response;
        }
    }
}
