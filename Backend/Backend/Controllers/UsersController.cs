using AutoMapper;
using Backend.Infrastructure;
using Backend.Models.Dtos;
using Backend.Models.Requests;
using Backend.Models.Responses;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(
            IUsersService usersService,
            IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _usersService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var result = await _usersService.CreateUserAsync(_mapper.Map<BaseUserDto>(request));
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(DeleteUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest<int> request)
        {
            var result = await _usersService.DeleteUserAsync(request.Id);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest<int> request)
        {
            var result = await _usersService.UpdateUserAsync(_mapper.Map<UserDto>(request));
            return Ok(result);
        }
    }
}
