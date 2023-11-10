using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using System.Data;

namespace MyPortfolio.Core.Projects.Save;

public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;
    private readonly IMapper _mapper;

    public AddProjectCommandHandler(MyPortfolioDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            string photoFolderPath = "wwwroot/images";

            var info = await _context.AboutMe.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID);

            if (info == null)
            {
                throw new ArgumentException("Not found!");
            }

            var project = _mapper.Map<Project>(request);

            string extension = Path.GetExtension(request.PhotoProjectUrl.FileName);
            string fileName = $"{Guid.NewGuid().ToString()}{extension}";
            string filePath = Path.Combine(photoFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.PhotoProjectUrl.CopyToAsync(stream);
            }

            project.PhotoProjectUrl = fileName;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Unit.Value;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while saving the project: {ex.Message}", ex);
        }
    }
}
