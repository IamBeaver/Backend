using AutoMapper;
using Backend.Models.Dtos;
using Backend.Repository.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersRepository(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(BaseUserDto userDto)
        {
            var user = await _dbContext.Users.AddAsync(new User { FirstName = userDto.FirstName, LastName = userDto.LastName, Age = userDto.Age });
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

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<bool> Update(UserDto userDto)
        {
            var local = _dbContext.Set<User>().Local.FirstOrDefault(entry => entry.Id.Equals(userDto.Id));
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            _dbContext.Entry(_mapper.Map<User>(userDto)).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
