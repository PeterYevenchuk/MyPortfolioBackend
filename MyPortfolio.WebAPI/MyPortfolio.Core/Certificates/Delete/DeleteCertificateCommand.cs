using MediatR;

namespace MyPortfolio.Core.Certificates.Delete;

public class DeleteCertificateCommand : IRequest<Unit>
{
    public int CertificateID { get; set; }
}
