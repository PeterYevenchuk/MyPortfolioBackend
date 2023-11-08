using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Certificates.Post;

namespace MyPortfolio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("certificate")]
    public async Task<IActionResult> AddCertificate([FromForm] AddCertificateCommand request)
    {
        await _mediator.Send(request);

        return Ok("The certificate was created successfully.");
    }
}
