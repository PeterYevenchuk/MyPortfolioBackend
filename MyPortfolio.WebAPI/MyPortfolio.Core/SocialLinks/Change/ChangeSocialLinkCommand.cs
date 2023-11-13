using MediatR;

namespace MyPortfolio.Core.SocialLinks.Change;

public class ChangeSocialLinkCommand : IRequest<Unit>
{
    public int SocialLinkID { get; set; }

    public string? Name { get; set; }

    public string? URL { get; set; }

    public int AboutMeID { get; set; }
}
