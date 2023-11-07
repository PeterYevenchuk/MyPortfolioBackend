using MyPortfolio.Core.InfoAboutMe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Core.Certificates;

public class Certificate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CertificateID { get; set; }

    public byte[] CertificatePdf { get; set; }

    public int AboutMeID { get; set; }

    [ForeignKey("AboutMeID")]
    public AboutMe AboutMe { get; set; }
}
