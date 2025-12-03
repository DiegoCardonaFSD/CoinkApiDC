using Microsoft.AspNetCore.Mvc;

namespace CoinkApiDC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok(new { message = "ponggg" });
        }
    }
}
