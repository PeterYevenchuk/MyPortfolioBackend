using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Context;
using MyPortfolio.Core.Experiences;
using System.Data;

namespace MyPortfolio.Core.Skills.Save;

public class AddSkillCommandHandler : IRequestHandler<AddSkillCommand, Unit>
{
    private readonly MyPortfolioDbContext _context;
    private readonly IMapper _mapper;

    public AddSkillCommandHandler(MyPortfolioDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddSkillCommand request, CancellationToken cancellationToken)
    {
        var info = await _context.AboutMe.FirstOrDefaultAsync(a => a.AboutMeID == request.AboutMeID);

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            var skill = _mapper.Map<Skill>(request);

            _context.Skills.Add(skill);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Unit.Value;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception($"An error occurred while saving the skill: {ex.Message}", ex);
        }
    }
}
