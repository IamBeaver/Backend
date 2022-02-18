using AutoMapper;
using Backend.Models.Dtos;
using Backend.Repository.Interfaces;
using Backend.Services.Interfaces;
using DataAccess.Data;

namespace Backend.Services
{
    public class UsersService : BaseDataService<ApplicationDbContext>, IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersService(
            IUsersRepository usersRepository,
            IMapper mapper,
            ApplicationDbContext dbContext,
            ILogger<ApplicationDbContext> logger)
            : base(dbContext, logger)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateUserAsync(BaseUserDto userDto)
        {
            return await ExecuteSafe(async () =>
            {
                return await _usersRepository.Create(userDto);
            });
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await ExecuteSafe(async () =>
            {
                return await _usersRepository.Delete(id);
            });
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await ExecuteSafe(async () =>
            {
                return _mapper.Map<IEnumerable<UserDto>>(await _usersRepository.GetUsers());
            });
        }

        public async Task<bool> UpdateUserAsync(UserDto userDto)
        {
            return await ExecuteSafe(async () =>
            {
                return await _usersRepository.Update(userDto);
            });
        }
    }
}
