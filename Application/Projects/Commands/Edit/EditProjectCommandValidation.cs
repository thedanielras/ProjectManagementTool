using FluentValidation;

namespace Application.Projects.Commands.Edit 
{

    public class EditProjectCommandValidation : AbstractValidator<EditProjectCommand>
    {
        public EditProjectCommandValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required."); ;
            RuleFor(c => c.ResponsibleUserId).NotEmpty().WithMessage("Responsible user is required.");
            RuleFor(c => c.DepartmentId).NotEmpty().WithMessage("Department is required."); ;
            RuleFor(c => c.ProjectSources).NotEmpty().WithMessage("At least 1 project source should be provided."); ;
            RuleForEach(c => c.ProjectSources).ChildRules(projectSource =>
            {
                projectSource.RuleFor(p => p.SourceUrl).NotEmpty().WithMessage("Source URL field is required.");
                projectSource.RuleFor(p => p.Type).NotEmpty().WithMessage("Source type is required.");
            });
        }
    }
}