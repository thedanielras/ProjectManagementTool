using FluentValidation;

namespace Application.Projects.Queries.GetProjectForRemoval
{
    public class GetProjectForRemovalValidator : AbstractValidator<GetProjectForRemovalQuery>
    {
        public GetProjectForRemovalValidator()
        {
            RuleFor( q => q.ProjectId).NotEmpty().WithMessage("Project id is required.");
        }
    }
}