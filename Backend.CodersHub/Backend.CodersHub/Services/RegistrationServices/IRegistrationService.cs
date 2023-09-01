using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Services.RegistrationServices
{
    public interface IRegistrationService
    {
        Guid Register(string firstName, string lastName, string bio, string emailAddress, string password);
        Guid Login(string emailAddress, string password);
    
    }
}
