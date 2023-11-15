using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Certificates.Post;
using MyPortfolio.Core.Educations.Save;
using MyPortfolio.Core.Experiences.Save;
using MyPortfolio.Core.Projects.Save;
using MyPortfolio.Core.Skills.Save;
using MyPortfolio.Core.SocialLinks.Save;

namespace MyPortfolio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminSaveController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminSaveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("certificate")]
    public async Task<IActionResult> AddCertificate([FromForm] AddCertificateCommand request)
    {
        await _mediator.Send(request);

        return Ok("The certificate was created successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("education")]
    public async Task<IActionResult> AddEducation(AddEducationCommand request)
    {
        await _mediator.Send(request);

        return Ok("The education was created successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("experience")]
    public async Task<IActionResult> AddExperience(AddExperienceCommand request)
    {
        await _mediator.Send(request);

        return Ok("The experience was created successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("project")]
    public async Task<IActionResult> AddProject([FromForm] AddProjectCommand request)
    {
        await _mediator.Send(request);

        return Ok("The project was created successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("skill")]
    public async Task<IActionResult> AddSkill(AddSkillCommand request)
    {
        await _mediator.Send(request);

        return Ok("The skill was created successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("social-link")]
    public async Task<IActionResult> AddSocialLinkl(AddSocialLinkCommand request)
    {
        await _mediator.Send(request);

        return Ok("The social link was created successfully.");
    }
}
