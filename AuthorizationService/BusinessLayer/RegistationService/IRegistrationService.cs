using AuthorizationService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorizationService.BusinessLayer
{
    public interface IRegistrationService
    {
        ChatUser RegisterUser(ChatUser user);
        bool DeleteUser(ChatUser user);
    }
}
