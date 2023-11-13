using FluentValidation;

namespace MyPortfolio.Core.Certificates.Delete;

public class DeleteCertificateCommandValidator : AbstractValidator<DeleteCertificateCommand>
{
    public DeleteCertificateCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.CertificateID).NotEmpty().NotNull().GreaterThan(0);
    }
}
