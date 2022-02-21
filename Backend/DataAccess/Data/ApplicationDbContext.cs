using DataAccess.Data.Configurations;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsersEntityTypeConfiguration());

            builder.Entity<User>().HasData(
                new List<User>
                {
                    new User() { Id = 1, FirstName = "Igor", LastName = "Bobro", Age = 22 },
                    new User() { Id = 2, FirstName = "Andrew", LastName = "Ivanov", Age = 31 },
                    new User() { Id = 3, FirstName = "Stas", LastName = "Maratov", Age = 24 },
                    new User() { Id = 4, FirstName = "Max", LastName = "Braun", Age = 26 },
                    new User() { Id = 5, FirstName = "Alex", LastName = "Perov", Age = 56 }
                });
        }
    }
}
