using BuberDiner.Api.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDiner.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    #region Protected methods declaration

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
            return Problem();

        if (errors.All(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.c_Errors] = errors;
        var firstError = errors.FirstOrDefault();
        return Problem(firstError);
    }

    #endregion

    #region Private methods declaration

    private IActionResult Problem(Error error)
    {
        var statusCode = error switch
        {
            { Type: ErrorType.Validation } => StatusCodes.Status400BadRequest,
            { Type: ErrorType.Conflict } => StatusCodes.Status409Conflict,
            { Type: ErrorType.NotFound } => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors) modelStateDictionary.AddModelError(error.Code, error.Description);

        return ValidationProblem(modelStateDictionary);
    }

    #endregion
}