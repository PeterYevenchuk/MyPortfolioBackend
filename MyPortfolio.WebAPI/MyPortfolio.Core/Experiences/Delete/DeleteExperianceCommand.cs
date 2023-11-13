using MediatR;

namespace MyPortfolio.Core.Experiences.Delete;

public class DeleteExperianceCommand : IRequest<Unit>
{
    public int ExperienceID { get; set; }
}
