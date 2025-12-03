using CoinkApiDC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinkApiDC.Infrastructure.Seed
{
    public static class CountrySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Colombia", Code = "CO" }
            );
        }
    }
}
