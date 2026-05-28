using KairoApi.Business.User.Query;
using KairoApi.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairoApi.App.Controllers;

[ApiController]
[Route("api/task")]
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
}