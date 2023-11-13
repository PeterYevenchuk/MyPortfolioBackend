using FluentValidation;

namespace MyPortfolio.Core.Skills.Change;

public class ChangeSkillCommandValidator : AbstractValidator<ChangeSkillCommand>
{
    public ChangeSkillCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.SkillID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
