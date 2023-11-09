using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyPortfolio.Core.InfoAboutMe;

namespace MyPortfolio.Core.Experiences;

public class Experience
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExperienceID { get; set; }

    public string Place {  get; set; }

    public string Company { get; set; }

    public string Position { get; set; }

    public string Rang {  get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateFinish { get; set;}

    public string Description { get; set; }

    public int AboutMeID { get; set; }

    [ForeignKey("AboutMeID")]
    public AboutMe AboutMe { get; set; }
}
