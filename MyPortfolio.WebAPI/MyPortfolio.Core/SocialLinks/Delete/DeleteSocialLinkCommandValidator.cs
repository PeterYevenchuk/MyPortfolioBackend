using FluentValidation;

namespace MyPortfolio.Core.SocialLinks.Delete;

public class DeleteSocialLinkCommandValidator : AbstractValidator<DeleteSocialLinkCommand>
{
    public DeleteSocialLinkCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.SocialLinkID).NotEmpty().NotNull().GreaterThan(0);
    }
}
