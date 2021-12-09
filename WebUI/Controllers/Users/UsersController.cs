using Application.Common.Models;
using Application.UserRoles.Queries.GetAll;
using Application.Users.Commands.AdminCreate;
using Application.Users.Commands.Edit;
using Application.Users.Queries.GetById;
using Application.Users.Queries.GetDetails;
using Application.Users.Remove;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ViewModels.User.Create;
using WebUI.ViewModels.User.Details;
using WebUI.ViewModels.User.Edit;
using WebUI.ViewModels.User.Remove;

namespace WebUI.Controllers.Users
{
    [Authorize(Roles = "admin")]    
    public class UsersController : BaseController<UsersController>
    {        
        [HttpGet]
        public IActionResult Index() /*Entry point*/
        {
            return new RedirectToActionResult("List", "Users", new { }, true);
        }
      
        [HttpGet]
        public IActionResult List()
        { 
            return View();
        }
      
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

        [HttpGet]
        public async Task<IActionResult> EditModal(Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("Unexcpected query parameter");
            }

            var query = new GetUserByIdQuery();
            query.UserId = userId;           

            var user = await Mediator.Send(query);
            var allUserRoles = await Mediator.Send(new GetAllUserRolesQuery());       
            var userDto = Mapper.Map<EditUserCommand>(user);

            IEnumerable<SelectListItem> userRolesSelectList = allUserRoles.Select(x => new SelectListItem { Text = x.Name, Value = x.RoleId.ToString() }).ToList();

            var vm = new EditUserViewModel(userDto, userRolesSelectList);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Users/Partial/_EditUser.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm][Bind(Prefix = "User")] EditUserCommand command) 
        {
            var result = await Mediator.Send(command);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveModal(GetUserByIdQuery query)
        {
            var user = await Mediator.Send(query);           
            var userDto = Mapper.Map<RemoveUserDto>(user);

            var vm = new RemoveUserViewModel(userDto);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Users/Partial/_RemoveUser.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);
            return Json(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromForm][Bind(Prefix = "User")] RemoveUserCommand command)
        {           
            var result = await Mediator.Send(command);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreationModal()
        {           
            var allUserRoles = await Mediator.Send(new GetAllUserRolesQuery());       
            IEnumerable<SelectListItem> userRolesSelectList = allUserRoles.Select(x => new SelectListItem { Text = x.Name, Value = x.RoleId.ToString() }).ToList();
            var vm = new CreateUserViewModel(new AdminCreateUserCommand(), userRolesSelectList);
            var view = await ViewRenderService.RenderToStringAsync("~/Views/Users/Partial/_CreateUser.cshtml", vm);
            var result = Result.SuccessWithHtmlPayload(view);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm][Bind(Prefix = "User")] AdminCreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Json(result);
        }
    }
}
