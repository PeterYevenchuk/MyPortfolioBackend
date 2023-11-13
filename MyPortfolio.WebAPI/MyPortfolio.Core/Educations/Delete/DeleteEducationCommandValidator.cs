using FluentValidation;

namespace MyPortfolio.Core.Educations.Delete;

public class DeleteEducationCommandValidator : AbstractValidator<DeleteEducationCommand>
{
    public DeleteEducationCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.EducationID).NotEmpty().NotNull().GreaterThan(0);
    }
}
