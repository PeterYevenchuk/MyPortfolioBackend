using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.InfoAboutMe.Get;

namespace MyPortfolio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AboutMeInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AboutMeInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAboutMeInfo()
    {
        var query = new GetAboutMeQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
