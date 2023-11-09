using FluentValidation;

namespace MyPortfolio.Core.SocialLinks.Save;

public class AddSocialLinkCommandValidator : AbstractValidator<AddSocialLinkCommand>
{
    public AddSocialLinkCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.Name).NotEmpty().NotNull();
        RuleFor(u => u.URL).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
