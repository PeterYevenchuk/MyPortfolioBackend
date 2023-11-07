using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyPortfolio.Core.InfoAboutMe;

namespace MyPortfolio.Core.Projects;

public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectID { get; set; }

    public string Name { get; set; }

    public string PhotoProjectUrl { get; set; }

    public string Description { get; set; }

    public string GitHubUrl { get; set; }

    public int AboutMeID { get; set; }

    [ForeignKey("AboutMeID")]
    public AboutMe AboutMe { get; set; }
}
