using DataAccess.Data.Entities;
using DataAccess.Data;

namespace DataAccess.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                await context.Users.AddRangeAsync(GetPreconfiguredUsers());

                await context.SaveChangesAsync();
            }
        }
        public static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>
            {
                new User() { FirstName = "Igor", LastName = "Bobro", Age = 22 },
                new User() { FirstName = "Andrew", LastName = "Ivanov", Age = 31 },
                new User() { FirstName = "Stas", LastName = "Maratov", Age = 24 },
                new User() { FirstName = "Max", LastName = "Braun", Age = 26 },
                new User() { FirstName = "Alex", LastName = "Perov", Age = 56 }
            };
        }
    }
}
