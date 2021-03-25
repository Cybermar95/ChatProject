
using System;
using System.Linq;
using AuthorizationService.DataAcessLayer;
using AuthorizationService.Model;

namespace AuthorizationService.BusinessLayer
{
    public class AuthService : IAuthService
    {
        private readonly IAuthorizationServerDBContext _dbContext;

        public AuthService(IAuthorizationServerDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public ChatUser Authorize(string userName, string password)
        {
            var user = _dbContext.ChatUsers.FirstOrDefault(user => user.Name == userName && user.Password == password);

            if (user != null)
            {
                user.Token = Guid.NewGuid();
                _dbContext.ChatUsers.Update(user);
                return user;
            }

            return null;
        }

        public void LogOff(string UserName, Guid Token)
        {
            throw new NotImplementedException();
        }
    }


}