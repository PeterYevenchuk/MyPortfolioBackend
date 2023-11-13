using MediatR;

namespace MyPortfolio.Core.Projects.Delete;

public class DeleteProjectCommand : IRequest<Unit>
{
    public int ProjectID { get; set; }
}
