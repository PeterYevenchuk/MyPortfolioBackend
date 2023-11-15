using MediatR;

namespace MyPortfolio.Core.Users.JwtAuth;

public class JwtCommand : IRequest<string>
{
    public string Login { get; set; }

    public string Password { get; set; }
}
