using Microsoft.EntityFrameworkCore;
using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Domain.Entities;
using CoinkApiDC.Infrastructure.Data;
using System.Data;

namespace CoinkApiDC.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync(int? countryId = null)
        {
            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = countryId.HasValue
                ? "SELECT * FROM fn_get_departments(@p_country_id)"
                : "SELECT * FROM fn_get_departments()";
            cmd.CommandType = CommandType.Text;

            if (countryId.HasValue)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = "p_country_id";
                param.Value = countryId.Value;
                param.DbType = DbType.Int32;
                cmd.Parameters.Add(param);
            }

            using var reader = await cmd.ExecuteReaderAsync();
            var result = new List<Department>();
            while (await reader.ReadAsync())
            {
                result.Add(new Department
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    CountryId = reader.GetInt32(reader.GetOrdinal("CountryId"))
                });
            }
            return result;
        }

    }
}
