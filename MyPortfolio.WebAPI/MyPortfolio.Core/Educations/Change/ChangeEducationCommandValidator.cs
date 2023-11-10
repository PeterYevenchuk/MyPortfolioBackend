using FluentValidation;

namespace MyPortfolio.Core.Educations.Change;

public class ChangeEducationCommandValidator : AbstractValidator<ChangeEducationCommand>
{
    public ChangeEducationCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.EducationID).NotEmpty().NotNull().GreaterThan(0);
    }
}
