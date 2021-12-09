using System.Collections.Generic;
using Application.Users.Commands.AdminCreate;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.ViewModels.User.Create
{
    public class CreateUserViewModel
    {
        public AdminCreateUserCommand User { get; }
        public IEnumerable<SelectListItem> UserRolesSelectList { get; }
        public CreateUserViewModel(AdminCreateUserCommand user, IEnumerable<SelectListItem> userRolesSelectList)
        {
            User = user;
            UserRolesSelectList = userRolesSelectList;
        }
    }
}