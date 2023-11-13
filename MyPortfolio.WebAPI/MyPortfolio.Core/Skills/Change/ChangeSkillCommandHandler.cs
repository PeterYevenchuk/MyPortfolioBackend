using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Skills.Change;

public class ChangeSkillCommandHandler : IRequestHandler<ChangeSkillCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public ChangeSkillCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ChangeSkillCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.Skills.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID && a.SkillID == request.SkillID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            info.MySkill = request.MySkill ?? info.MySkill;

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
