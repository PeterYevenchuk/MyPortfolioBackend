using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyPortfolio.Core.InfoAboutMe;

namespace MyPortfolio.Core.Educations;

public class Education
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EducationID { get; set; }

    public string Rang {  get; set; }

    public string Speciality { get; set; }

    public string University { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateFinish { get; set; }

    public string Description { get; set; }

    public int AboutMeID { get; set; }

    [ForeignKey("AboutMeID")]
    public AboutMe AboutMe { get; set; }
}
