using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Certificates.Post;
using MyPortfolio.Core.Educations.Save;
using MyPortfolio.Core.InfoAboutMe.ChangeInfo;

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

    [HttpPost("education")]
    public async Task<IActionResult> AddEducation(AddEducationCommand request)
    {
        await _mediator.Send(request);

        return Ok("The education was created successfully.");
    }

    [HttpPatch("change-my-info")]
    public async Task<IActionResult> ChangeInfoAbouthMe([FromForm] ChangeInfoAboutMeCommand request)
    {
        await _mediator.Send(request);

        return Ok("Successful!");
    }
}
