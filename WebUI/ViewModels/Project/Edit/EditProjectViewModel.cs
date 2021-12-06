using Application.Projects.Queries.GetProjectDetails;
using Application.Projects.Queries.GetProjectEditData;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebUI.ViewModels.Project.Edit
{
    public class EditProjectViewModel
    {
        public IEnumerable<SelectListItem> DepartmentSelectList { get; }
        public IEnumerable<SelectListItem> UserSelectList { get; }
        public IEnumerable<SelectListItem> ProjectSourceTypeSelectList { get; }
        public ProjectEditDto Project { get; }

        public EditProjectViewModel(ProjectEditDto project,
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
