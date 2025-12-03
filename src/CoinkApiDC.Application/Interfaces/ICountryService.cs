using CoinkApiDC.Domain.Entities;

namespace CoinkApiDC.Application.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
