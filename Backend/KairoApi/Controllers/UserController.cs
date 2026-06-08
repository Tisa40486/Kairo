using KairoApi.Business.User.Command;
using KairoApi.Business.User.Query;
using KairoApi.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairoApi.App.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("get/{id}")]
    public async Task<ActionResult<UserResponse?>> GetUserByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery { Id = id });

        return Ok(result);
    }
    
    [HttpPost("createUser")]
    public async Task<ActionResult<TaskReponse?>> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpPost("loginUser")]
    public async Task<ActionResult<TaskReponse?>> LoginUser([FromBody] LoginUserCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(token);
    }
}