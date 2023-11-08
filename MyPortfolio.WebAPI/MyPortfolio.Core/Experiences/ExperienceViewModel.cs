namespace MyPortfolio.Core.Experiences;

public class ExperienceViewModel
{
    public int ExperienceID { get; set; }

    public string Place { get; set; }

    public string Company { get; set; }

    public string Position { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateFinish { get; set; }

    public string Description { get; set; }
}
