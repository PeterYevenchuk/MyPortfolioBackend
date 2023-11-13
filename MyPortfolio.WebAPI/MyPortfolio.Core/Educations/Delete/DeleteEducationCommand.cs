using MediatR;

namespace MyPortfolio.Core.Educations.Delete;

public class DeleteEducationCommand : IRequest<Unit>
{
    public int EducationID { get; set; }
}
