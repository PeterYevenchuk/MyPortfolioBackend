using FluentValidation;

namespace MyPortfolio.Core.Skills.Save;

public class AddSkillCommandValidator : AbstractValidator<AddSkillCommand>
{
    public AddSkillCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.MySkill).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
