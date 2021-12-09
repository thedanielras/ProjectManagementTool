using FluentValidation;

namespace Application.Projects.Commands.Remove 
{
    public class RemoveProjectCommandValidation : AbstractValidator<RemoveProjectCommand>
    {
        public RemoveProjectCommandValidation() 
        {
            RuleFor(c => c.ProjectId).NotEmpty().WithMessage("Project id was not provided or not valid.");
        }
    }
}