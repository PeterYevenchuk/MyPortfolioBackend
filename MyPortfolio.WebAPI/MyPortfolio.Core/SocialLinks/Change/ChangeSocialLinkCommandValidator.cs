using FluentValidation;


namespace MyPortfolio.Core.SocialLinks.Change;

public class ChangeSocialLinkCommandValidator : AbstractValidator<ChangeSocialLinkCommand>
{
    public ChangeSocialLinkCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.SocialLinkID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
