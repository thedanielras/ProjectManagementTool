using Application.Common.Exceptions;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        public ExceptionFilter()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException }             
            };
        }

        public void OnException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (ValidationException)context.Exception;
            var errors = exception.Errors.Values.SelectMany(x => x).ToList();
            context.Result = new BadRequestObjectResult(Result.Error(errors));
            context.ExceptionHandled = true;
        }
        
        private void HandleNotFoundException(ExceptionContext context)
        {          
            context.Result = new NotFoundObjectResult(Result.Error(new List<string> { "Entity not found!" }));
            context.ExceptionHandled = true;
        }        
        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(Result.Error(new List<string> { "Ivalid model state!" }));
            context.ExceptionHandled = true;
        }        
        private void HandleUnknownException(ExceptionContext context)
        {
            context.Result = new JsonResult(Result.Error(new List<string> { "Generic Error" }));
            context.ExceptionHandled = true;
        }
    }
}
