namespace CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Application.DTOs;

public interface IUserService
{
    Task<(int userId, int addressId)> CreateUserAsync(CreateUserRequest request);
}
