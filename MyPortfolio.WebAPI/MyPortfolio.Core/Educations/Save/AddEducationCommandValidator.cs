using FluentValidation;

namespace MyPortfolio.Core.Educations.Save;

public class AddEducationCommandValidator : AbstractValidator<AddEducationCommand>
{
    public AddEducationCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.Speciality).NotEmpty().NotNull();
        RuleFor(u => u.University).NotEmpty().NotNull();
        RuleFor(u => u.Rang).NotEmpty().NotNull();
        RuleFor(u => u.Description).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.DateStart).NotEmpty().NotNull();
    }
}
