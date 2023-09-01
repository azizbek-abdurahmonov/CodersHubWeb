using Backend.CodersHub.Models;
using Backend.CodersHub.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Backend.CodersHub.Files
{
    public partial class FileContext : IFileContext
    {
        public Guid AddUser(User user)
        {
            var allText = File.ReadAllText(_usersPath);
            var users = new List<User>();

            if (allText.Length == 0)
            {
                users.Add(user);
            }
            else
            {
                users = JsonSerializer.Deserialize<List<User>>(allText);
                users.Add(user);
            }

            WriteAllText(_usersPath, JsonSerializer.Serialize(users));
            return user.Token;
        }

        public void DeleteUser(Guid token)
        {
            var allText = File.ReadAllText(_usersPath);
            if (allText.Length == 0) return;

            var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_usersPath));
            var user = users.FirstOrDefault(x => x.Token == token);

            if (user != null)
            {
                user.IsDeleted = true;
            }

            WriteAllText(_usersPath, JsonSerializer.Serialize(users));
        }

        public User GetUser(Guid token)
        {
            var allText = File.ReadAllText(_usersPath);
            if (allText.Length == 0) return null;

            var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_usersPath));
            return users.FirstOrDefault(user => user.Token == token);
        }

        public User GetUser(string emailAddress, string password)
        {
            var allText = File.ReadAllText(_usersPath);
            if (allText.Length == 0) return null;

            var users = JsonSerializer.Deserialize<List<User>>(allText);
            return users.FirstOrDefault(user => (user.EmailAddress == emailAddress && user.Password == password));
        }

        public void UpdateUser(Guid token, UserDto user)
        {
            var allText = File.ReadAllText(_usersPath);
            if (allText.Length == 0) return;

            var users = JsonSerializer.Deserialize<List<User>>(allText);
            var foundedUser = users.FirstOrDefault(u => u.Token == token);

            if (foundedUser != null)
            {
                foundedUser.FirstName = user.FirstName;
                foundedUser.LastName = user.LastName;
                foundedUser.Bio = user.Bio;
                foundedUser.EmailAddress = user.EmailAddress;
                foundedUser.Password = user.Password;
            }

            WriteAllText(_usersPath, JsonSerializer.Serialize(users));
        }


        public List<User> GetUsers()
        {
            var allText = File.ReadAllText(_usersPath);
            if (allText.Length == 0) return new List<User>();

            var users = JsonSerializer.Deserialize<List<User>>(allText);
            return users.Where(x => !x.IsDeleted).ToList();
        }



    }
}
