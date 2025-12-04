using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoinkApiDC.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var result = await _userService.CreateUserAsync(request);
        return Ok(new { UserId = result.userId, AddressId = result.addressId });
    }
}
