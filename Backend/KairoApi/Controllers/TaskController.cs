using KairoApi.Business.Task.Command;
using KairoApi.Business.Task.Query;
using KairoApi.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairoApi.App.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<TaskReponse?>> GetTaskByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<TaskReponse?>> CreateTaskAsync([FromBody] CreateTaskCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<TaskReponse?>> DeleteTaskByIdAsync(int id)
        {
            await _mediator.Send(new DeleteTaskCommand { Id = id});
            return Ok();
        }
    }
}