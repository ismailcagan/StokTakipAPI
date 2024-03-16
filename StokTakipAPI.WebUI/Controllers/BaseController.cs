using Microsoft.AspNetCore.Mvc;
using StokTakipAPI.Business.ReturnModels;

namespace StokTakipAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(ReturnModel<T> result)
        {
            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.Created:
                    return Created("/", result);
                case System.Net.HttpStatusCode.OK:
                    return Ok(result);
                case System.Net.HttpStatusCode.BadRequest:
                    return BadRequest(result);
                default:
                    return NotFound(result);
            }
        }
    }
}
