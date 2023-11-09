using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using MyPortfolio.Core.Educations;
using MyPortfolio.Core.Projects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Core.Experiences.Save;

public class AddExperienceCommandHandler : IRequestHandler<AddExperienceCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;
    private readonly IMapper _mapper;

    public AddExperienceCommandHandler(MyPortfolioDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddExperienceCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.AboutMe.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            var experience = _mapper.Map<Experience>(request);

            _context.Experiences.Add(experience);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Unit.Value;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while saving the experience: {ex.Message}", ex);
        }
    }
}
