using FluentValidation;

namespace MyPortfolio.Core.InfoAboutMe.ChangeInfo;

public class ChangeInfoAboutMeCommandValidator : AbstractValidator<ChangeInfoAboutMeCommand>
{
    public ChangeInfoAboutMeCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.Age).GreaterThan((byte)0);
        RuleFor(u => u.AboutMeID).GreaterThan(0).NotEmpty().NotNull();
    }
}
