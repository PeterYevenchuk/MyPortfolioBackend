namespace MyPortfolio.Core.Certificates;

public class CertificateViewModel
{
    public int CertificateID { get; set; }

    public string Name { get; set; }

    public byte[] CertificatePdf { get; set; }
}
