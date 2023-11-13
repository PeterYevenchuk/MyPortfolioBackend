using FluentValidation;

namespace MyPortfolio.Core.Projects.Change;

public class ChangeProjectCommandValidator : AbstractValidator<ChangeProjectCommand>
{
    public ChangeProjectCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.ProjectID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
