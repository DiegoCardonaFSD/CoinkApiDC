using Microsoft.AspNetCore.Mvc;
using CoinkApiDC.Application.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _service;

    public CitiesController(ICityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? departmentId)
    {
        var cities = await _service.GetAllCitiesAsync(departmentId);
        return Ok(cities);
    }
}
