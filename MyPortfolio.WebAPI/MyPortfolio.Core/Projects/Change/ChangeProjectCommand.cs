using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Core.Projects.Change;

public class ChangeProjectCommand : IRequest<Unit>
{
    public int ProjectID { get; set; }

    public string? Name { get; set; }

    public IFormFile? PhotoProjectUrl { get; set; }

    public string? Description { get; set; }

    public string? GitHubUrl { get; set; }

    public int AboutMeID { get; set; }
}
