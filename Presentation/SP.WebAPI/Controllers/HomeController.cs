using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SP.Application.CQRS.Commands;
using SP.Application.CQRS.Queries;

namespace SP.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController: ControllerBase
    {
        private IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
 
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            return Ok(await mediator.Send(command));
        }
 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllStudentQuery()));
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await mediator.Send(new GetStudentByIdQuery { Id = id }));
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await mediator.Send(new DeleteStudentByIdCommand { Id = id }));
        }
 
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            if (command.Id==Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }
    }
}