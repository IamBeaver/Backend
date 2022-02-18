using Backend.Models.Dtos;
using DataAccess.Data.Entities;

namespace Backend.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<int> Create(BaseUserDto userDto);
        Task<bool> Update(UserDto userDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}
