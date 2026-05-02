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
    }
}
