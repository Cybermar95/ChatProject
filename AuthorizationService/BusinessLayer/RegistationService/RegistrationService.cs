using AuthorizationService.DataAcessLayer;
using AuthorizationService.Model;
using System;
using System.Linq;

namespace AuthorizationService.BusinessLayer
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IAuthorizationServerDBContext _dbContext;

        public RegistrationService(IAuthorizationServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool DeleteUser(ChatUser user)
        {
            throw new NotImplementedException();
        }

        public ChatUser RegisterUser(ChatUser user)
        {
            var isUserExists = _dbContext.ChatUsers.Any(u => u.Name == user.Name);
            if (!isUserExists)
            {
                user.UserToken = Guid.NewGuid();
                _dbContext.ChatUsers.Add(user);
            }
            return isUserExists 
                   ? null
                   : user;
        }
    }
}
