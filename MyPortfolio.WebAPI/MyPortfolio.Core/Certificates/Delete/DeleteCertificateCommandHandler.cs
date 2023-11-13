using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;

namespace MyPortfolio.Core.Certificates.Delete;

public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public DeleteCertificateCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var info = await _context.Certificates.FirstOrDefaultAsync(a => a.CertificateID == request.CertificateID);

                if (info == null)
                {
                    throw new ArgumentException("Not found!");
                }

                _context.Certificates.Remove(info);
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
}
