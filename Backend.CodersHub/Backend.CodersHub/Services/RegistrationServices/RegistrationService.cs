using Backend.CodersHub.Services.UserServices;
using Backend.CodersHub.Services.UserServices.Concrete;
using Backend.CodersHub.Services.ValidatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Services.RegistrationServices
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Validator _validator;
        private readonly UserService _userService;

        public RegistrationService()
        {
            _validator = new Validator();
            _userService = new UserService();
        }

        public Guid Register(string firstName, string lastName, string bio, string emailAddress, string password)
        {
            if (!_validator.IsValidName(firstName)) throw new Exception("First name is not valid!");
            if (!_validator.IsValidName(lastName)) throw new Exception("Last name is not valid");
            if (!_validator.IsValidEmailAddress(emailAddress)) throw new Exception("Email address is not valid");
            if (!_validator.IsValidPassword(password)) throw new Exception("Password is not valid");
            if (!_validator.IsUniqueEmail(emailAddress, _userService.GetUsers())) throw new Exception("Email address is already used");

            var userDto = new UserDto(firstName, lastName, bio, emailAddress, password);
            return _userService.Add(userDto);
        }

        public Guid Login(string emailAddress, string password)
        {
            var user = _userService.Get(emailAddress, password);
            if (user != null)
            {
                return user.Token;
            }

            throw new Exception("Email or password incorrect");

        }
    }
}
