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
                                IEnumerable<SelectListItem> reposnsibleUserSelectList,
                                IEnumerable<SelectListItem> responsibleUserItaliaSelectList)
        {
            DepartmentSelectList = departmentSelectList;
            ReposnsibleUserSelectList = reposnsibleUserSelectList;
            ResponsibleUserItaliaSelectList = responsibleUserItaliaSelectList;
        }

        public IEnumerable<SelectListItem> DepartmentSelectList { get; private set; }
        public IEnumerable<SelectListItem> ReposnsibleUserSelectList { get; private set; }
        public IEnumerable<SelectListItem> ResponsibleUserItaliaSelectList { get; private set; }
    }
}
