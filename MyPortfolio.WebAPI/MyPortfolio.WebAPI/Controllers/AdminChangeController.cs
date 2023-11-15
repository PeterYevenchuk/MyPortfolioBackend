using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Certificates.Change;
using MyPortfolio.Core.Educations.Change;
using MyPortfolio.Core.Experiences.Change;
using MyPortfolio.Core.InfoAboutMe.ChangeInfo;
using MyPortfolio.Core.Projects.Change;
using MyPortfolio.Core.Skills.Change;
using MyPortfolio.Core.SocialLinks.Change;

namespace MyPortfolio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminChangeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminChangeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-my-info")]
    public async Task<IActionResult> ChangeInfoAbouthMe([FromForm] ChangeInfoAboutMeCommand request)
    {
        await _mediator.Send(request);

        return Ok("The information was changed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-certificate")]
    public async Task<IActionResult> ChangeCertificate([FromForm] ChangeCertificateCommand request)
    {
        await _mediator.Send(request);

        return Ok("The certificate was changed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-education")]
    public async Task<IActionResult> ChangeEducation(ChangeEducationCommand request)
    {
        await _mediator.Send(request);

        return Ok("The education was changed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-experiance")]
    public async Task<IActionResult> ChangeExperiance(ChangeExperianceCommand request)
    {
        await _mediator.Send(request);

        return Ok("The experiance was changed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-project")]
    public async Task<IActionResult> ChangeProject([FromForm] ChangeProjectCommand request)
    {
        await _mediator.Send(request);

        return Ok("The project was changed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-skill")]
    public async Task<IActionResult> ChangeSkill(ChangeSkillCommand request)
    {
        await _mediator.Send(request);

        return Ok("The skill was changed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("change-social-link")]
    public async Task<IActionResult> ChangeSocialLink(ChangeSocialLinkCommand request)
    {
        await _mediator.Send(request);

        return Ok("The social link was changed successfully.");
    }
}
