using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;

namespace MyPortfolio.Core.Projects.Delete;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public DeleteProjectCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        string photoFolderPath = "wwwroot/images";

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var info = await _context.Projects.FirstOrDefaultAsync(a => a.ProjectID == request.ProjectID);

                if (info == null)
                {
                    throw new ArgumentException("Not found!");
                }

                if (!string.IsNullOrEmpty(info.PhotoProjectUrl))
                {
                    string oldFilePath = Path.Combine(photoFolderPath, info.PhotoProjectUrl);
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                _context.Projects.Remove(info);
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
