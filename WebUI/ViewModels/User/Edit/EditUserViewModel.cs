using Application.Users.Queries.GetEditData;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebUI.ViewModels.User.Edit
{
    public class EditUserViewModel
    {
        public GetUserEditDataUserDto User { get; }
        public IEnumerable<SelectListItem> UserRolesSelectList { get; }

        public EditUserViewModel(GetUserEditDataUserDto user, IEnumerable<SelectListItem> userRolesSelectList)
        {
            User = user;
            UserRolesSelectList = userRolesSelectList;
        }
    }
}
