using CoinkApiDC.Application.DTOs;

namespace CoinkApiDC.Application.Interfaces
{
    public interface IUserService
{
    Task<(int userId, int addressId)> CreateUserAsync(CreateUserRequest request);
}
}
