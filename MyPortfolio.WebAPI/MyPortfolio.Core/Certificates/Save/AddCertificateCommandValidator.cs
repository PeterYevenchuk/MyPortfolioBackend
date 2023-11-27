using FluentValidation;

namespace MyPortfolio.Core.Certificates.Post;

public class AddCertificateCommandValidator : AbstractValidator<AddCertificateCommand>
{
    public AddCertificateCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.CertificatePdf).NotEmpty().NotNull();
        RuleFor(u => u.AboutMeID).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(u => u.Name).NotEmpty().NotNull();
    }
}
