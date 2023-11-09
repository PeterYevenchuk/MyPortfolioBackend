using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.Context;
using MyPortfolio.Core.SocialLinks;
using System.Data;

namespace MyPortfolio.Core.Educations.Save;

public class AddEducationCommandHandler : IRequestHandler<AddEducationCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;
    private readonly IMapper _mapper;

    public AddEducationCommandHandler(MyPortfolioDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddEducationCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.AboutMe.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            var education = _mapper.Map<Education>(request);

            _context.Educations.Add(education);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while saving the education: {ex.Message}", ex);
        }

        return Unit.Value;
    }
}
