using MediatR;

namespace MyPortfolio.Core.Skills.Delete;

public class DeleteSkillCommand : IRequest<Unit>
{
    public int SkillID { get; set; }
}
