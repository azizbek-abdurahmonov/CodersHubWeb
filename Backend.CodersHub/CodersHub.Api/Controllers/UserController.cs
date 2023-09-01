using Backend.CodersHub.Files;
using Backend.CodersHub.Models;
using Backend.CodersHub.Services;
using Backend.CodersHub.Services.UserServices;
using Backend.CodersHub.Services.UserServices.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CodersHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpPost("AddUser")]
        public Guid AddUser(UserDto user)
        {
            return _userService.Add(user);
        }

        [HttpPost("UpdateUser")]
        public void UpdateUser(Guid token, string currentPassword, UserDto userDto)
        {
            _userService.Update(token, currentPassword, userDto);
        }

        [HttpDelete("DeleteUser")]
        public void DeleteUser(Guid token)
        {
            _userService.Delete(token);
        }

        [HttpGet("GetUser")]
        public User GetUser(Guid token)
        {
            return _userService.Get(token);
        }

        [HttpGet("GetUsers")]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }
    }
}
