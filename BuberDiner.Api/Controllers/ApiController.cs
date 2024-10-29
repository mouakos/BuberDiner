using BuberDiner.Api.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.c_Errors] = errors;
            var firstError = errors.FirstOrDefault();
            var statusCode = firstError switch
            {
                { Type: ErrorType.Validation } => StatusCodes.Status400BadRequest,
                { Type: ErrorType.Conflict } => StatusCodes.Status409Conflict,
                { Type: ErrorType.NotFound } => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }
}