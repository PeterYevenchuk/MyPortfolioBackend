using MediatR;

namespace MyPortfolio.Core.Educations.Save;

public class AddEducationCommand : IRequest<Unit>
{
    public string Rang { get; set; }

    public string Speciality { get; set; }

    public string University { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateFinish { get; set; }

    public string? Description { get; set; }

    public int AboutMeID { get; set; }
}
