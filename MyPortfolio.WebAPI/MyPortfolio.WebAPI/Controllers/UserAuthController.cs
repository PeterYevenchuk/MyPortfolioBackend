using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Users.JwtAuth;

namespace MyPortfolio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserAuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("auth/{login}/{password}")]
    public async Task<IActionResult> GetAccessToken(string login, string password)
    {
        var request = new JwtCommand { Login = login, Password = password };
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}
