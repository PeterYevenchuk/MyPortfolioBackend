using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Certificates.Change;
using MyPortfolio.Core.Certificates.Post;
using MyPortfolio.Core.Educations.Change;
using MyPortfolio.Core.Educations.Save;
using MyPortfolio.Core.Experiences.Change;
using MyPortfolio.Core.Experiences.Save;
using MyPortfolio.Core.InfoAboutMe.ChangeInfo;
using MyPortfolio.Core.Projects.Save;
using MyPortfolio.Core.Skills.Save;
using MyPortfolio.Core.SocialLinks.Save;

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

    [HttpPost("experience")]
    public async Task<IActionResult> AddExperience(AddExperienceCommand request)
    {
        await _mediator.Send(request);

        return Ok("The experience was created successfully.");
    }

    [HttpPost("project")]
    public async Task<IActionResult> AddProject([FromForm] AddProjectCommand request)
    {
        await _mediator.Send(request);

        return Ok("The project was created successfully.");
    }

    [HttpPost("skill")]
    public async Task<IActionResult> AddSkill(AddSkillCommand request)
    {
        await _mediator.Send(request);

        return Ok("The skill was created successfully.");
    }

    [HttpPost("social-link")]
    public async Task<IActionResult> AddSocialLinkl(AddSocialLinkCommand request)
    {
        await _mediator.Send(request);

        return Ok("The social link was created successfully.");
    }

    [HttpPatch("change-my-info")]
    public async Task<IActionResult> ChangeInfoAbouthMe([FromForm] ChangeInfoAboutMeCommand request)
    {
        await _mediator.Send(request);

        return Ok("The information was changed successfully.");
    }

    [HttpPatch("change-certificate")]
    public async Task<IActionResult> ChangeCertificate([FromForm] ChangeCertificateCommand request)
    {
        await _mediator.Send(request);

        return Ok("The certificate was changed successfully.");
    }

    [HttpPatch("change-education")]
    public async Task<IActionResult> ChangeEducation(ChangeEducationCommand request)
    {
        await _mediator.Send(request);

        return Ok("The education was changed successfully.");
    }

    [HttpPatch("change-experiance")]
    public async Task<IActionResult> ChangeExperiance(ChangeExperianceCommand request)
    {
        await _mediator.Send(request);

        return Ok("The experiance was changed successfully.");
    }
}
