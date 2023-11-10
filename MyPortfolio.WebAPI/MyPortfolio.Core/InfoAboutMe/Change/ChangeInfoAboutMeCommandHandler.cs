using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;

namespace MyPortfolio.Core.InfoAboutMe.ChangeInfo;

public class ChangeInfoAboutMeCommandHandler : IRequestHandler<ChangeInfoAboutMeCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;
    private readonly IMapper _mapper;

    public ChangeInfoAboutMeCommandHandler(MyPortfolioDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeInfoAboutMeCommand request, CancellationToken cancellationToken)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                string photoFolderPath = "wwwroot/images";

                var info = await _context.AboutMe.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID);

                if (info == null)
                {
                    throw new ArgumentException("Not found!");
                }

                info.Name = request.Name ?? info.Name;
                info.Surname = request.Surname ?? info.Surname;
                info.Age = request.Age ?? info.Age;
                info.Location = request.Location ?? info.Location;
                info.Position = request.Position ?? info.Position;
                info.Description = request.Description ?? info.Description;

                if (request.PhotoMe != null)
                {
                    string extension = Path.GetExtension(request.PhotoMe.FileName);
                    string fileName = $"{Guid.NewGuid().ToString()}{extension}";
                    string filePath = Path.Combine(photoFolderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.PhotoMe.CopyToAsync(stream);
                    }

                    info.PhotoMeUrl = fileName;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }

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
