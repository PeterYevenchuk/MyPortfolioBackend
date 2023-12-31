﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Core.Certificates.Post;

public class AddCertificateCommand : IRequest<Unit>
{
    public string Name { get; set; }

    public IFormFile CertificatePdf { get; set; }

    public int AboutMeID { get; set; }
}
