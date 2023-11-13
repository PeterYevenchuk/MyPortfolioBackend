using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;

namespace MyPortfolio.Core.Educations.Delete;

public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public DeleteEducationCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var info = await _context.Educations.FirstOrDefaultAsync(a => a.EducationID == request.EducationID);

                if (info == null)
                {
                    throw new ArgumentException("Not found!");
                }

                _context.Educations.Remove(info);
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
