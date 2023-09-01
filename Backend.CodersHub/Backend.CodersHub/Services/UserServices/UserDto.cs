using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Services.UserServices
{
    public class UserDto
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string Bio { get;set; }
        public string EmailAddress { get;set; }
        public string Password { get;set; }

        public UserDto(string firstName, string lastName, string bio, string emailAddress, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            EmailAddress = emailAddress;
            Password = password;
        }

        public UserDto()
        {
            
        }
    }
}
