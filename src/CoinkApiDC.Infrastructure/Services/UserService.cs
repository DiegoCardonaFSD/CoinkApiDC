using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Application.DTOs;
using CoinkApiDC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CoinkApiDC.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(int userId, int addressId)> CreateUserAsync(CreateUserRequest request)
    {
        using var conn = _context.Database.GetDbConnection();
        await conn.OpenAsync();
        using var transaction = await conn.BeginTransactionAsync();

        using var cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_create_user";
        cmd.Transaction = transaction;

        var nameParam = cmd.CreateParameter();
        nameParam.ParameterName = "p_name";
        nameParam.Value = request.Name;
        cmd.Parameters.Add(nameParam);

        var phoneParam = cmd.CreateParameter();
        phoneParam.ParameterName = "p_phone";
        phoneParam.Value = request.Phone;
        cmd.Parameters.Add(phoneParam);

        var cityParam = cmd.CreateParameter();
        cityParam.ParameterName = "p_city_id";
        cityParam.Value = request.CityId;
        cmd.Parameters.Add(cityParam);

        var streetParam = cmd.CreateParameter();
        streetParam.ParameterName = "p_street";
        streetParam.Value = request.Address;
        cmd.Parameters.Add(streetParam);

        var userIdParam = cmd.CreateParameter();
        userIdParam.ParameterName = "p_user_id";
        userIdParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(userIdParam);

        var addressIdParam = cmd.CreateParameter();
        addressIdParam.ParameterName = "p_address_id";
        addressIdParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(addressIdParam);

        await cmd.ExecuteNonQueryAsync();
        await transaction.CommitAsync();

        return (userIdParam.Value as int? ?? 0, addressIdParam.Value as int? ?? 0);
    }
}
