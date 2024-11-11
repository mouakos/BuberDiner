using BuberDiner.Api.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace BuberDiner.Api.Common.Errors
{
    public class BuberDinnerProblemDetailsFactory(
        IOptions<ApiBehaviorOptions> options,
        IOptions<ProblemDetailsOptions>? problemDetailsOptions = null)
        : ProblemDetailsFactory
    {
        #region Private fields declaration

        private readonly Action<ProblemDetailsContext>? m_Configure =
            problemDetailsOptions?.Value?.CustomizeProblemDetails;

        private readonly ApiBehaviorOptions m_Options =
            options?.Value ?? throw new ArgumentNullException(nameof(options));

        #endregion

        #region Public methods declaration

        /// <inheritdoc />
        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null)
        {
            statusCode ??= 500;

            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            ModelStateDictionary modelStateDictionary,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null)
        {
            ArgumentNullException.ThrowIfNull(modelStateDictionary);

            statusCode ??= 400;

            ValidationProblemDetails problemDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode, Type = type, Detail = detail, Instance = instance
            };

            if (title != null)
                // For validation problem details, don't overwrite the default title with null.
            {
                problemDetails.Title = title;
            }

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        #endregion

        #region Private methods declaration

        private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if (m_Options.ClientErrorMapping.TryGetValue(statusCode, out ClientErrorData? clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            if (httpContext?.Items[HttpContextItemKeys.c_Errors] is List<Error> errors)
            {
                problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
            }

            string? traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

            m_Configure?.Invoke(new ProblemDetailsContext
            {
                HttpContext = httpContext!, ProblemDetails = problemDetails
            });
        }

        #endregion
    }
}