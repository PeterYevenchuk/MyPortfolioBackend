using MediatR;

namespace MyPortfolio.Core.Certificates.Post;

public class AddCertificateCommand : IRequest<Unit>
{
    public byte[] CertificatePdf { get; set; }
}
