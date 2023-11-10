using FluentValidation;

namespace MyPortfolio.Core.Certificates.Change;

public class ChangeCertificateCommandValidator : AbstractValidator<ChangeCertificateCommand>
{
    public ChangeCertificateCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.CertificateID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
