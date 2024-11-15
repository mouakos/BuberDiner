﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDiner.Api.Common.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        #region Public methods declaration

        public override void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;

            ProblemDetails problemDetails = new ProblemDetails
            {
                Type = "http://tools.ietf.org/tml/rfc7231#section-6.6.1",
                Title = "An error occured while processing request.",
                Status = (int)HttpStatusCode.InternalServerError
            };

            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }

        #endregion
    }
}