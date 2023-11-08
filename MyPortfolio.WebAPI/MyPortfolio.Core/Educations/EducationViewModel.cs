namespace MyPortfolio.Core.Educations;

public class EducationViewModel
{
    public int EducationID { get; set; }

    public string Rang { get; set; }

    public string Speciality { get; set; }

    public string University { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateFinish { get; set; }

    public string Description { get; set; }
}
