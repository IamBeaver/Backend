using Backend.Models.Dtos;

namespace Backend.Services.Interfaces
{
    public interface IUsersService
    {
        Task<int> CreateUserAsync(BaseUserDto userDto);
        Task<bool> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
