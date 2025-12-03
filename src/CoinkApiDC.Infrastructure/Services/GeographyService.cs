using Microsoft.EntityFrameworkCore;
using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Domain.Entities;
using CoinkApiDC.Infrastructure.Data;
using System.Data;

namespace CoinkApiDC.Infrastructure.Services
{
    public class GeographyService : ICountryService, IDepartmentService, ICityService
    {
        private readonly AppDbContext _context;

        public GeographyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM fn_get_countries()";
            cmd.CommandType = CommandType.Text;

            using var reader = await cmd.ExecuteReaderAsync();
            var result = new List<Country>();
            while (await reader.ReadAsync())
            {
                result.Add(new Country
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Code = reader.GetString(reader.GetOrdinal("Code"))
                });
            }
            return result;
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
