using MediatR;

namespace MyPortfolio.Core.SocialLinks.Delete;

public class DeleteSocialLinkCommand : IRequest<Unit>
{
    public int SocialLinkID { get; set; }
}
