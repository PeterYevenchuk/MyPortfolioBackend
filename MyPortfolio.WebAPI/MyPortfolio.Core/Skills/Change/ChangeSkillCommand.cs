using MediatR;

namespace MyPortfolio.Core.Skills.Change;

public class ChangeSkillCommand : IRequest<Unit>
{
    public int SkillID { get; set; }

    public string? MySkill { get; set; }

    public int AboutMeID { get; set; }
}
