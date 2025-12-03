using Microsoft.AspNetCore.Mvc;
using CoinkApiDC.Application.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _service;

    public CountriesController(ICountryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var countries = await _service.GetAllCountriesAsync();
        return Ok(countries);
    }
}
