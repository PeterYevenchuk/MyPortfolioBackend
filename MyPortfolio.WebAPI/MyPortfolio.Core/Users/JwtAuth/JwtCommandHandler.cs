using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPortfolio.Core.Context;
using MyPortfolio.Core.Helpers.PasswordHasher;


namespace MyPortfolio.Core.Users.JwtAuth;

public class JwtCommandHandler : IRequestHandler<JwtCommand, string>
{
    private readonly MyPortfolioDbContext _context;
    private readonly string _jwtApiKey;
    private readonly IPasswordHash _hasher;

    public JwtCommandHandler(MyPortfolioDbContext context, IConfiguration configuration, IPasswordHash hasher)
    {
        _context = context;
        _hasher = hasher;
        _jwtApiKey = configuration.GetValue<string>("JWTSettings:ApiKey");
    }

    public async Task<string> Handle(JwtCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(a => a.Login == request.Login);
        if (user is null)
        {
            throw new InvalidDataException("Wrong credentials!");
        }

        var passwordHash = _hasher.EncryptPassword(request.Password, Convert.FromBase64String(user.Salt));

        if (user.Password == passwordHash)
        {
            var accessToken = TokenUtilities.CreateToken(user, _jwtApiKey);

            return accessToken;
        }
        else
        {
            throw new InvalidDataException("Wrong credentials!");
        }
    }
}
