using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Educations.Change;

public class ChangeEducationCommandHandler : IRequestHandler<ChangeEducationCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public ChangeEducationCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ChangeEducationCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.Educations.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID && a.EducationID == request.EducationID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            info.Rang = request.Rang ?? info.Rang;
            info.Speciality = request.Speciality ?? info.Speciality;
            info.University = request.University ?? info.University;
            info.DateStart = request.DateStart ?? info.DateStart;
            info.DateFinish = request.DateFinish ?? info.DateFinish;
            info.Description = request.Description ?? info.Description;

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
