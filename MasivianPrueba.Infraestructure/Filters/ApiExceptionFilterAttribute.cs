﻿using MasivianPrueba.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;


namespace MasivianPrueba.Infraestructure.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        #region ctor
        public ApiExceptionFilterAttribute()
        {
            
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(EntityNotFoundException), HandleNotFoundException }

            };
       
        }
        #endregion ctor
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }
        private void HandleException(ExceptionContext context)
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
        private void HandleUnknownException(ExceptionContext context)
        {
            ProblemDetails details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            ValidationProblemDetails details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
        private void HandleNotFoundException(ExceptionContext context)
        {
            EntityNotFoundException exception = context.Exception as EntityNotFoundException;

            ProblemDetails details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
       

    }
}
