using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.BusinessLayer
{
    public interface IRegistrationService
    {
        ActionResult<AccessTokens> RegisterUser(ChatUsers user);
        bool DeleteUser(ChatUsers user);
    }
}
