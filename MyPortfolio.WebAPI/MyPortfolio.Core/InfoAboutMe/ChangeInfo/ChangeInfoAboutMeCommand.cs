using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Core.InfoAboutMe.ChangeInfo;

public class ChangeInfoAboutMeCommand : IRequest<Unit>
{
    public int AboutMeID { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public byte? Age { get; set; }

    public string? Location { get; set; }

    public string? Position { get; set; }

    public IFormFile? PhotoMe { get; set; }

    public string? Description { get; set; }
}
