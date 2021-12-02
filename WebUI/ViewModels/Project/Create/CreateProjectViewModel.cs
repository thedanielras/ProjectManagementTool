using Application.Projects.Commands.Create;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebUI.ViewModels.Project.Create
{
    public class CreateProjectViewModel
    {
        public CreateProjectViewModel(IEnumerable<SelectListItem> departmentSelectList,
                                IEnumerable<SelectListItem> userSelectList,
                                IEnumerable<SelectListItem> projectSourceTypeSelectList)
        {
            DepartmentSelectList = departmentSelectList;
            UserSelectList = userSelectList;
            ProjectSourceTypeSelectList = projectSourceTypeSelectList;
        }

        public IEnumerable<SelectListItem> DepartmentSelectList { get; private set; }
        public IEnumerable<SelectListItem> UserSelectList { get; private set; }
        public IEnumerable<SelectListItem> ProjectSourceTypeSelectList { get; private set; }
        public CreateProjectCommand Project { get; set; }
    }
}
