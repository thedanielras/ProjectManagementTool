using Application.Users.Commands.Edit;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebUI.ViewModels.User.Edit
{
    public class EditUserViewModel
    {
        public EditUserCommand User { get; }
        public IEnumerable<SelectListItem> UserRolesSelectList { get; }

        public EditUserViewModel(EditUserCommand user, IEnumerable<SelectListItem> userRolesSelectList)
        {
            User = user;
            UserRolesSelectList = userRolesSelectList;
        }
    }
}
