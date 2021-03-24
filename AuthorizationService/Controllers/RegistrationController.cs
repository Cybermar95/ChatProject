using AuthorizationService.BusinessLayer;
using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthorizationService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public ActionResult<ChatUser> RegisterUser([FromBody] ChatUser chatUser) => _registrationService.RegisterUser(chatUser); // )

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
