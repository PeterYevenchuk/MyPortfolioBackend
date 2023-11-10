using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Experiences.Change;

public class ChangeExperianceCommandHandler : IRequestHandler<ChangeExperianceCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public ChangeExperianceCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ChangeExperianceCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.Experiences.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID && a.ExperienceID == request.ExperienceID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            info.Rang = request.Rang ?? info.Rang;
            info.Place = request.Place ?? info.Place;
            info.Company = request.Company ?? info.Company;
            info.DateStart = request.DateStart ?? info.DateStart;
            info.DateFinish = request.DateFinish ?? info.DateFinish;
            info.Description = request.Description ?? info.Description;
            info.Position = request.Position ?? info.Position;

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
