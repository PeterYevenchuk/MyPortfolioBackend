using MediatR;

namespace MyPortfolio.Core.Skills.Save;

public class AddSkillCommand : IRequest<Unit>
{
    public string MySkill { get; set; }

    public int AboutMeID { get; set; }
}
