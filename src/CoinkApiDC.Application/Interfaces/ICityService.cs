using CoinkApiDC.Domain.Entities;

namespace CoinkApiDC.Application.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCitiesAsync(int? departmentId = null);
    }
}
