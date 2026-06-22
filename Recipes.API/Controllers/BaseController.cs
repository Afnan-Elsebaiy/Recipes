using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Common.Responses;

namespace Recipes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleResponse<T>(ApiResponse<T> response)
        {
            return StatusCode(response.StatusCode, response);
        }
    }
}
