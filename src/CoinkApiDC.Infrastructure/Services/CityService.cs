using Microsoft.EntityFrameworkCore;
using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Domain.Entities;
using CoinkApiDC.Infrastructure.Data;
using System.Data;

namespace CoinkApiDC.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly AppDbContext _context;

        public CityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync(int? departmentId = null)
        {
            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = departmentId.HasValue
                ? "SELECT * FROM fn_get_cities(@p_department_id)"
                : "SELECT * FROM fn_get_cities()";
            cmd.CommandType = CommandType.Text;

            if (departmentId.HasValue)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = "p_department_id";
                param.Value = departmentId.Value;
                param.DbType = DbType.Int32;
                cmd.Parameters.Add(param);
            }

            using var reader = await cmd.ExecuteReaderAsync();
            var result = new List<City>();
            while (await reader.ReadAsync())
            {
                result.Add(new City
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId"))
                });
            }
            return result;
        }
    }
}
