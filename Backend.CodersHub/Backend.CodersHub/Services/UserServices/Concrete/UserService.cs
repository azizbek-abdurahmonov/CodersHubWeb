using Backend.CodersHub.Files;
using Backend.CodersHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Services.UserServices.Concrete
{
    public class UserService : IUserService
    {
        private readonly IFileContext _fileContext;

        public UserService()
        {
            _fileContext = new FileContext();
        }

        public Guid Add(UserDto userDto)
        {
            var user = new
                User(userDto.FirstName,
                userDto.LastName,
                userDto.Bio,
                userDto.EmailAddress,
                userDto.Password);

            return _fileContext.AddUser(user);
        }

        public void Delete(Guid token)
        {
            _fileContext.DeleteUser(token);
        }

        public User Get(Guid token)
        {
            return _fileContext.GetUser(token);
        }
        public User Get(string emailAddress, string password)
        {
            return _fileContext.GetUser(emailAddress, password);
        }

        public void Update(Guid token, string currentPassword, UserDto user)
        {
            var foundedUser = _fileContext.GetUser(token);
            if (foundedUser.Password != currentPassword)
            {
                throw new Exception("Old password is not valid");
            }

            _fileContext.UpdateUser(token, user);
        }

        public List<User> GetUsers()
        {
            return _fileContext.GetUsers();
        }

    }
}
