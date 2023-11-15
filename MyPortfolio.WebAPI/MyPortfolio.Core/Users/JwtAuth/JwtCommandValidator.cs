using FluentValidation;

namespace MyPortfolio.Core.Users.JwtAuth;

public class JwtCommandValidator : AbstractValidator<JwtCommand>
{
    public JwtCommandValidator()
    {
        RuleFor(query => query).NotNull().NotEmpty();
        RuleFor(query => query.Login).NotNull().NotEmpty();
        RuleFor(query => query.Password).NotNull().NotEmpty();
    }
}
