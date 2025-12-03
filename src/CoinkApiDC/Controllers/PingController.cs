using Microsoft.AspNetCore.Mvc;

namespace CoinkApiDC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok(new { message = "pongg" });
        }
    }
}
