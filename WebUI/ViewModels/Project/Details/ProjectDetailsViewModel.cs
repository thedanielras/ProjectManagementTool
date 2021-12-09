using Application.Projects.Queries.GetProjectDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebUI.ViewModels.Project.Details
{
    public class ProjectDetailsViewModel
    {
        public IEnumerable<SelectListItem> DepartmentSelectList { get; }
        public IEnumerable<SelectListItem> UserSelectList { get; }
        public IEnumerable<SelectListItem> ProjectSourceTypeSelectList { get; }
        public ProjectDetailsDto Project { get; }

        public ProjectDetailsViewModel(ProjectDetailsDto project,
                                IEnumerable<SelectListItem> departmentSelectList,
                               IEnumerable<SelectListItem> userSelectList,
                               IEnumerable<SelectListItem> projectSourceTypeSelectList)
        {
            DepartmentSelectList = departmentSelectList;
            UserSelectList = userSelectList;
            ProjectSourceTypeSelectList = projectSourceTypeSelectList;
            Project = project;
        }
    }
}
