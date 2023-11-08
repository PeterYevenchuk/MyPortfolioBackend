using MediatR;

namespace MyPortfolio.Core.Certificates.Post;

public class AddCertificateCommandHandler : IRequestHandler<AddCertificateCommand, Unit>
{
    public Task<Unit> Handle(AddCertificateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
