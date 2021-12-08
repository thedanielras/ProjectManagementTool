using System.Collections.Generic;
using Application.Projects.Queries.GetProjectForRemoval;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.ViewModels.Project.Remove
{
    public class RemoveProjectViewModel
    {      
        public ProjectForRemovalDto Project { get; }

        public RemoveProjectViewModel(ProjectForRemovalDto project)
        {         
            Project = project;
        }
    }
}
