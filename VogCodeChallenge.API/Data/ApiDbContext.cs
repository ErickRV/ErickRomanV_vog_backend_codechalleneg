using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.Domain.Entities;

namespace VogCodeChallenge.API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Department>().HasIndex(d => d.Address).IsUnique();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
