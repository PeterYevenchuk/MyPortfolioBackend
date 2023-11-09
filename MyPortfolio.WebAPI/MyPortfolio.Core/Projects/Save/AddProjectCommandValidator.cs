using FluentValidation;

namespace MyPortfolio.Core.Projects.Save;

public class AddProjectCommandValidator : AbstractValidator<AddProjectCommand>
{
    public AddProjectCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.PhotoProjectUrl).NotEmpty().NotNull();
        RuleFor(u => u.Name).NotEmpty().NotNull();
        RuleFor(u => u.GitHubUrl).NotEmpty().NotNull();
        RuleFor(u => u.Description).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
