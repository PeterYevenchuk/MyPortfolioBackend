using MediatR;

namespace MyPortfolio.Core.SocialLinks.Save;

public class AddSocialLinkCommand : IRequest<Unit>
{
    public string Name { get; set; }

    public string URL { get; set; }

    public int AboutMeID { get; set; }
}
