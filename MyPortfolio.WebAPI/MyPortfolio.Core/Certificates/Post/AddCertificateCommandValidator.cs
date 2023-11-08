using FluentValidation;

namespace MyPortfolio.Core.Certificates.Post;

public class AddCertificateCommandValidator : AbstractValidator<AddCertificateCommand>
{
    public AddCertificateCommandValidator()
    {
        RuleFor(u => u).NotEmpty();
        RuleFor(u => u.CertificatePdf).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
    }
}
