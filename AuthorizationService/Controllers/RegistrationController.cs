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
        public ActionResult<ChatUser> RegisterUser([FromBody] ChatUser chatUser)
        { 
            var user = _registrationService.RegisterUser(chatUser);
            return (ActionResult<ChatUser>)user ?? NotFound();
        }

        [HttpGet]
        public string CheckCookies() 
        {

            return Request.Cookies["token"];
        } 

    }
}
