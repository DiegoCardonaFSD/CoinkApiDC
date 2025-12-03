using CoinkApiDC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinkApiDC.Infrastructure.Seed
{
    public static class DepartmentSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, CountryId = 1, Name = "Antioquia" },
                new Department { Id = 2, CountryId = 1, Name = "Cundinamarca" },
                new Department { Id = 3, CountryId = 1, Name = "Valle del Cauca" }
            );
        }
    }
}
