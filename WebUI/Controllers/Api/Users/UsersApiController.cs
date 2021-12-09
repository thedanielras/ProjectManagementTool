using Application.Users.Queries.GetList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers.Api.Users
{
    [Route("api/users")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class UsersApiController : BaseApiController<UsersApiController>
    {
        [Route("list")]
        public async Task<JsonResult> List() 
        {
            var result = await Mediator.Send(new GetUsersListResultQuery());
            return new JsonResult(result);
        }

    }
}
