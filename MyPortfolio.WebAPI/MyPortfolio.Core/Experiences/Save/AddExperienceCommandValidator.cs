using FluentValidation;

namespace MyPortfolio.Core.Experiences.Save;

public class AddExperienceCommandValidator : AbstractValidator<AddExperienceCommand>
{
    public AddExperienceCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.Place).NotEmpty().NotNull();
        RuleFor(u => u.Company).NotEmpty().NotNull();
        RuleFor(u => u.Position).NotEmpty().NotNull();
        RuleFor(u => u.Rang).NotEmpty().NotNull();
        RuleFor(u => u.Description).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.DateStart).NotEmpty().NotNull();
    }
}
