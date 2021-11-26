using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class AddProjectViewModel
    {

        public AddProjectViewModel(IEnumerable<SelectListItem> departmentSelectList,
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
    }
}
