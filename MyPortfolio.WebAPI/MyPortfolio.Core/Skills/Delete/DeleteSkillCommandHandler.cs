using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;

namespace MyPortfolio.Core.Skills.Delete;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public DeleteSkillCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var info = await _context.Skills.FirstOrDefaultAsync(a => a.SkillID == request.SkillID);

                if (info == null)
                {
                    throw new ArgumentException("Not found!");
                }

                _context.Skills.Remove(info);
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
