using FluentValidation;

namespace MyPortfolio.Core.Experiences.Delete;

internal class DeleteExperianceCommandValidator : AbstractValidator<DeleteExperianceCommand>
{
    public DeleteExperianceCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.ExperienceID).NotEmpty().NotNull().GreaterThan(0);
    }
}
