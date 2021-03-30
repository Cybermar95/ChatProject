using AuthorizationService.BusinessLayer;
using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthorizationService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public ActionResult<AccessTokens> RegisterUser([FromBody] ChatUsers chatUser) 
            => _registrationService.RegisterUser(chatUser);
    }
}
