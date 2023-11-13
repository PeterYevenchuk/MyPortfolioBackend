using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.SocialLinks.Change;

public class ChangeSocialLinkCommandHandler : IRequestHandler<ChangeSocialLinkCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public ChangeSocialLinkCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ChangeSocialLinkCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.SocialLinks.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID && a.SocialLinkID == request.SocialLinkID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            info.Name = request.Name ?? info.Name;
            info.URL = request.URL ?? info.URL;

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
