
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

        [HttpGet("{userName}/{password}")]
        public ActionResult<ChatUser> AuthorizeUser(string userName, string password)
        {
            var user = _authorizationService.Authorize(userName, password);
            return (ActionResult<ChatUser>)user ?? BadRequest();
        }

    }
}
