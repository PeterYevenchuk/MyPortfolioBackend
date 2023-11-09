using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Certificates.Post;

public class AddCertificateCommandHandler : IRequestHandler<AddCertificateCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public AddCertificateCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddCertificateCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.AboutMe.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            var certificate = new Certificate();

            using (var ms = new MemoryStream())
            {
                await request.CertificatePdf.CopyToAsync(ms);
                certificate.CertificatePdf = ms.ToArray();
                certificate.AboutMeID = request.AboutMeID;
            }

            _context.Certificates.Add(certificate);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while saving the certificate: {ex.Message}", ex);
        }

        return Unit.Value;
    }
}
