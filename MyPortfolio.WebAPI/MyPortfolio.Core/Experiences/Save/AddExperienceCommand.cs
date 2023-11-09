using MediatR;

namespace MyPortfolio.Core.Experiences.Save;

public class AddExperienceCommand : IRequest<Unit>
{
    public string Place { get; set; }

    public string Company { get; set; }

    public string Position { get; set; }

    public string Rang { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateFinish { get; set; }

    public string Description { get; set; }

    public int AboutMeID { get; set; }
}
