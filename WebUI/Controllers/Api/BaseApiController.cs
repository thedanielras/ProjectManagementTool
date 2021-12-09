using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase
    {
        private ILogger<T> _logger = null!;
        private IMediator _mediator = null!;

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
