using Application.Users.Queries.GetList;
using Application.Users.Queries.GetUsersDataTableQuery;
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
        [HttpGet("list")]
        public async Task<JsonResult> List() 
        {
            var result = await Mediator.Send(new GetUsersListResultQuery());
            return new JsonResult(result);
        }

        [HttpPost("datatable")]
        public async Task<JsonResult> DataTable([FromForm] GetUsersDataTableQuery query)
        {
            var result = await Mediator.Send(query);

            return new JsonResult(result);
        }
    }
}
