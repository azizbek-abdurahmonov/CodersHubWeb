using Backend.CodersHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Backend.CodersHub.Services.ValidatorService
{
    public class Validator
    {
        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (name.Any(x => Char.IsDigit(x) || Char.IsSymbol(x) || x == ' '))
                return false;

            var formattedName = string.Concat(
                name.Substring(0, 1).ToUpper(),
                name.Substring(1).ToLower());

            if (name != formattedName) return false;

            return true;
        }

        public bool IsValidEmailAddress(string emailAddress) => Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        public bool IsValidPassword(string password) => Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=])(?!.*\s).{8,}$");

        public bool IsUniqueEmail(string emailAddress, List<User> users)
        {
            if (users.Any(user => user.EmailAddress == emailAddress))
                return false;

            return true;
        }
    }
}
