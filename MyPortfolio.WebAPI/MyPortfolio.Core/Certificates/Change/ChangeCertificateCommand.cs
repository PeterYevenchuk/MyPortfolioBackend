using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Core.Certificates.Change;

public class ChangeCertificateCommand : IRequest<Unit>
{
    public int CertificateID { get; set; }

    public IFormFile? CertificatePdf { get; set; }

    public string? Name { get; set; }

    public int AboutMeID { get; set; }
}
