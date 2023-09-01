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
        private readonly string _usersPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString(), "Backend.CodersHub", "Backend.CodersHub", "DataLayer", "users.json");
        private readonly string _postsPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.ToString(), "Backend.CodersHub", "Backend.CodersHub", "DataLayer", "posts.json");

        public FileContext()
        {
            if (!File.Exists(_usersPath))
                File.Create(_usersPath).Close();
            if (!File.Exists(_postsPath))
                File.Create(_postsPath).Close();
        }

        private void WriteAllText(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}
