using Microsoft.AspNetCore.Mvc;
using CoinkApiDC.Application.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _service;

    public DepartmentsController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? countryId)
    {
        var departments = await _service.GetAllDepartmentsAsync(countryId);
        return Ok(departments);
    }
}
