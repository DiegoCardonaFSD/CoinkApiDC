using Microsoft.EntityFrameworkCore;
using CoinkApiDC.Application.Interfaces;
using CoinkApiDC.Domain.Entities;
using CoinkApiDC.Infrastructure.Data;
using System.Data;

namespace CoinkApiDC.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _context;

        public CountryService(AppDbContext context)
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

       
    }
}
