using Application.Common.Models;
using Application.UserRoles.Queries.GetAll;
using Application.Users.Queries.GetDetails;
using Application.Users.Queries.GetEditData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ViewModels.User.Details;
using WebUI.ViewModels.User.Edit;

namespace WebUI.Controllers.Users
{
    [Authorize(Roles = "admin")]
    public class UsersController : BaseController<UsersController>
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult Index() /*Entry point*/
        {
            return new RedirectToActionResult("List", "Users", new { }, true);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult List()
        { 
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> DetailsModal(Guid userId)
        {
            var query = new GetUserDetailsQuery();
            query.UserId = userId;

            if (query.UserId == null)
            {
                throw new ArgumentException("Unexcpected query parameter");
            }

            var user = await Mediator.Send(query);
            var vm = new UserDetailsViewModel(user);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Users/Partial/_UserDetails.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<IActionResult> EditModal(Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("Unexcpected query parameter");
            }

            var query = new GetUserEditDataQuery();
            query.UserId = userId;           

            var user = await Mediator.Send(query);
            var allUserRoles = await Mediator.Send(new GetAllUserRolesQuery());       

            IEnumerable<SelectListItem> userRolesSelectList = allUserRoles.Select(x => new SelectListItem { Text = x.Name, Value = x.RoleId.ToString() }).ToList();

            var vm = new EditUserViewModel(user, userRolesSelectList);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Users/Partial/_EditUser.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }

    }
}
