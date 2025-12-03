using CoinkApiDC.Domain.Entities;

namespace CoinkApiDC.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync(int? countryId = null);
    }
}
