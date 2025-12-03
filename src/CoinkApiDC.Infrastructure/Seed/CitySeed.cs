using CoinkApiDC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinkApiDC.Infrastructure.Seed
{
    public static class CitySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                // Antioquia
                new City { Id = 1, DepartmentId = 1, Name = "Medellín" },
                new City { Id = 2, DepartmentId = 1, Name = "Envigado" },
                new City { Id = 3, DepartmentId = 1, Name = "Marinilla" },

                // Cundinamarca
                new City { Id = 4, DepartmentId = 2, Name = "Bogotá" },
                new City { Id = 5, DepartmentId = 2, Name = "Cajicá" },
                new City { Id = 6, DepartmentId = 2, Name = "Chía" },

                // Valle del Cauca
                new City { Id = 7, DepartmentId = 3, Name = "Cali" },
                new City { Id = 8, DepartmentId = 3, Name = "Palmira" },
                new City { Id = 9, DepartmentId = 3, Name = "Buenaventura" }
            );
        }
    }
}
