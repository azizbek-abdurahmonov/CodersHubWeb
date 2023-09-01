using Backend.CodersHub.Services.RegistrationServices;
using Microsoft.AspNetCore.Mvc;

namespace CodersHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController()
        {
            _registrationService = new RegistrationService();
        }

        [HttpPost("Register")]
        public Guid Register(string firstName, string lastName, string bio, string emailAddress, string password)
        {
            return _registrationService.Register(firstName, lastName, bio, emailAddress, password);
        }

        [HttpPost("Login")]
        public Guid Login(string emailAddress, string password)
        {
            return _registrationService.Login(emailAddress, password);
        }
    }
}
