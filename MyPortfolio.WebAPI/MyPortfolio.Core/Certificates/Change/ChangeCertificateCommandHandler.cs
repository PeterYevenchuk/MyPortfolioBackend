using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Certificates.Change;

public class ChangeCertificateCommandHandler : IRequestHandler<ChangeCertificateCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public ChangeCertificateCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ChangeCertificateCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.Certificates.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID && a.CertificateID == request.CertificateID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            if (request.CertificatePdf != null)
            {
                using (var ms = new MemoryStream())
                {
                    await request.CertificatePdf.CopyToAsync(ms);
                    info.CertificatePdf = ms.ToArray();
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Unit.Value;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while processing the request: {ex.Message}", ex);
        }
    }
}
