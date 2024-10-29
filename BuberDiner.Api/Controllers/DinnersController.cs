using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    #region Public methods declaration

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Array.Empty<string>());
    }

    #endregion
}