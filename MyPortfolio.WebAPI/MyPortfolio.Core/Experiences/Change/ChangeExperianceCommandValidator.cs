using FluentValidation;

namespace MyPortfolio.Core.Experiences.Change;

public class ChangeExperianceCommandValidator : AbstractValidator<ChangeExperianceCommand>
{
    public ChangeExperianceCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.ExperienceID).NotEmpty().NotNull().GreaterThan(0);
    }
}
