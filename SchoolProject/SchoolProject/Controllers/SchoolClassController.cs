using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.ControllersFilters;
using SchoolProject.Common.DTO.SchoolClassController;
using SchoolProject.Infrastructure.Command;
using System;
using System.Threading.Tasks;

namespace SchoolProject.API.Controllers
{
    [Route("api/class")]
    [TypeFilter(typeof(ExceptionFilter))]
    public class SchoolClassController : Controller
    {
        private readonly IMediator mediator;

        public SchoolClassController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Guid>> AddClass([FromBody] AddSchoolClassDTO dto )
        {
            var result = await mediator.Send(new AddSchoolClassCommand(dto.Group, dto.LanguageGroups));

            return result;
        }
    }
}
