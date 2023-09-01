using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Token { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public User(string firstName, string lastName, string bio, string emailAddress, string password, bool isDeleted = false)
        {
            //Id = Guid.NewGuid();
            //Token = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            EmailAddress = emailAddress;
            Password = password;
            IsDeleted = isDeleted;
        }
    }
}
