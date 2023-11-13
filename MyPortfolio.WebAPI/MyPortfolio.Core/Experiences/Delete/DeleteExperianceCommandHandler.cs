using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;

namespace MyPortfolio.Core.Experiences.Delete;

public class DeleteExperianceCommandHandler : IRequestHandler<DeleteExperianceCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public DeleteExperianceCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteExperianceCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var info = await _context.Experiences.FirstOrDefaultAsync(a => a.ExperienceID == request.ExperienceID);

                if (info == null)
                {
                    throw new ArgumentException("Not found!");
                }

                _context.Experiences.Remove(info);
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
