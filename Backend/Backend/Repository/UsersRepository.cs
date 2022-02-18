using Backend.Repository.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(string firstName, string lastName, int age)
        {
            var user = await _dbContext.Users.AddAsync(new User { FirstName = firstName, LastName = lastName, Age = age });
            await _dbContext.SaveChangesAsync();
            return user.Entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                _dbContext.Users.Remove(await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException("User wasn't found"));
                await _dbContext.SaveChangesAsync();
            }
            catch (NullReferenceException)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<User>> Read()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<bool> Update(int id, string firstName, string lastName, int age)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                return false;
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Age = age;

            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
