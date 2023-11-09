using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Core.Projects.Save;

public class AddProjectCommand : IRequest<Unit>
{
    public string Name { get; set; }

    public IFormFile PhotoProjectUrl { get; set; }

    public string Description { get; set; }

    public string GitHubUrl { get; set; }

    public int AboutMeID { get; set; }
}
