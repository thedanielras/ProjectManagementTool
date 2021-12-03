using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Projects.Commands.Create
{
    public class CreateProjectCommandValidation : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidation()
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
