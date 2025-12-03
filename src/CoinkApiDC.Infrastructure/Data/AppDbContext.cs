using Microsoft.EntityFrameworkCore;
using CoinkApiDC.Domain.Entities;
using CoinkApiDC.Infrastructure.Seed;


namespace CoinkApiDC.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Country> Countries => Set<Country>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Phone).HasMaxLength(20);

            modelBuilder.Entity<Address>().Property(a => a.Street).HasMaxLength(150);

            modelBuilder.Entity<Country>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Country>().Property(c => c.Code).HasMaxLength(5);

            modelBuilder.Entity<Department>().Property(d => d.Name).HasMaxLength(100);
            modelBuilder.Entity<City>().Property(c => c.Name).HasMaxLength(100);

            CountrySeed.Seed(modelBuilder);
            DepartmentSeed.Seed(modelBuilder);
            CitySeed.Seed(modelBuilder);
        }
    }
}







