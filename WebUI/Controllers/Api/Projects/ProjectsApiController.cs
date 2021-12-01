using Application.Projects.Queries.GetAllProjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers.Api.Projects
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsApiController : BaseApiController<ProjectsApiController>
    {
        [HttpGet("test")]
        public JsonResult Test() 
        {
            return new JsonResult("success");
        }

        [HttpGet("list")]
        public async Task<JsonResult> List([FromQuery] GetAllProjectsQuery query)
        {          
            var result = await Mediator.Send(query);
                        
            return new JsonResult(result);
        }

    }
}
