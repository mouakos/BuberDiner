using System.Net;
using System.Text.Json;

namespace BuberDiner.Api.Common.Middleware
{
    public class ErrorHandlingMiddleware(RequestDelegate requestDelegate)
    {
        #region Public methods declaration

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception e)
            {
                // Log error
                await HandleExceptionAsync(httpContext, e);
            }
        }

        #endregion

        #region Private methods declaration

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            string result = JsonSerializer.Serialize(new { error = "An error occured while processing request." });

            await httpContext.Response.WriteAsync(result);
        }

        #endregion
    }
}