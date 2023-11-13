using FluentValidation;

namespace MyPortfolio.Core.Projects.Delete;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(u => u).NotEmpty().NotNull();
        RuleFor(u => u.ProjectID).NotEmpty().NotNull().GreaterThan(0);
    }
}
