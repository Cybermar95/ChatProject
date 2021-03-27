
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

        public ChatUser Authorize(string userName, string password) => _dbContext.ChatUsers.FirstOrDefault(user => user.Name == userName && user.Password == password);

        public void LogOff(string UserName, Guid Token)
        {
            throw new NotImplementedException();
        }
    }


}