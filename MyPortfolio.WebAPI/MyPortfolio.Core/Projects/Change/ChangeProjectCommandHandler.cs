using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Projects.Change;

public class ChangeProjectCommandHandler : IRequestHandler<ChangeProjectCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;

    public ChangeProjectCommandHandler(MyPortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ChangeProjectCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            string photoFolderPath = "wwwroot/images";

            var info = await _context.Projects.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID && a.ProjectID == request.ProjectID);

            if (info == null)
            {
                throw new ArgumentException("Not found!");
            }

            info.Name = request.Name ?? info.Name;
            info.Description = request.Description ?? info.Description;
            info.GitHubUrl = request.GitHubUrl ?? info.GitHubUrl;

            if (request.PhotoProjectUrl != null)
            {
                if (!string.IsNullOrEmpty(info.PhotoProjectUrl))
                {
                    string oldFilePath = Path.Combine(photoFolderPath, info.PhotoProjectUrl);
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                string extension = Path.GetExtension(request.PhotoProjectUrl.FileName);
                string fileName = $"{Guid.NewGuid().ToString()}{extension}";
                string filePath = Path.Combine(photoFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.PhotoProjectUrl.CopyToAsync(stream);
                }

                info.PhotoProjectUrl = fileName;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Unit.Value;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while processing the request:: {ex.Message}", ex);
        }
    }
}
