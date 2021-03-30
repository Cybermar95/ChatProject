
using AuthorizationService.BusinessLayer;
using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthService _authorizationService;

        public AuthorizeController(IAuthService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public ActionResult<AccessTokens> AuthorizeUser([FromBody] ChatUsers chatUser) 
            => _authorizationService.Authorize(chatUser.Name, chatUser.Password);
    }
}
