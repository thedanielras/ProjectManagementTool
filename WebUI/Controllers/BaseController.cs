﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebUI.Common.Interfaces;

namespace WebUI.Controllers
{
    public class BaseController<T> : Controller
    {
        private ILogger<T> _logger = null!;
        private IViewRenderService _viewRenderService = null!;
        private IMediator _mediator = null!;

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
        protected IViewRenderService ViewRenderService => _viewRenderService ??= HttpContext.RequestServices.GetRequiredService<IViewRenderService>();
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();     
    }
}
