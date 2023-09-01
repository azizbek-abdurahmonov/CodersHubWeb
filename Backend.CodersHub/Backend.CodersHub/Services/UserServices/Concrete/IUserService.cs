using Backend.CodersHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Services.UserServices.Concrete
{
    public interface IUserService
    {
        Guid Add(UserDto userDto);
        void Update(Guid token,string currentPassword, UserDto userDto);
        void Delete(Guid token);
        User Get(Guid token);
        User Get(string emailAddress, string password);
        List<User> GetUsers();
    }
}
