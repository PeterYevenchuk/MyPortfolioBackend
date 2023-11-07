using MyPortfolio.Core.InfoAboutMe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Core.SocialLinks;

public class SocialLink
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SocialLinkID { get; set; }

    public string Name { get; set; }

    public string URL { get; set; }

    public int AboutMeID { get; set; }

    [ForeignKey("AboutMeID")]
    public AboutMe AboutMe { get; set; }
}
