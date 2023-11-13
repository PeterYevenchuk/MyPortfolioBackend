using FluentValidation;

namespace MyPortfolio.Core.Skills.Delete;

public class DeleteSkillCommandValidator : AbstractValidator<DeleteSkillCommand>
{
    public DeleteSkillCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.SkillID).NotEmpty().NotNull().GreaterThan(0);
    }
}
