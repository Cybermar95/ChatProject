using AuthorizationService.DataAcessLayer;
using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AuthorizationService.BusinessLayer
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IAuthorizationServerDBContext _dbContext;
        private readonly ConflictResult _conflict = new();

        public RegistrationService(IAuthorizationServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool DeleteUser(ChatUsers user)
        {
            throw new NotImplementedException();
        }

        public ActionResult<AccessTokens> RegisterUser(ChatUsers user)
        {
            ActionResult<AccessTokens> result = _conflict;
            var isUserExists = _dbContext.ChatUsers.Any(u => u.Name == user.Name);
            if (!isUserExists)
            {
                var dbUser =_dbContext.ChatUsers.Add(user);

                _dbContext.SaveChanges();

                

                var newToken = new AccessTokens() {
                                                   UserID = dbUser.Entity.ID, 
                                                   Token = Guid.NewGuid() };


                _dbContext.AcessTokens.Add(newToken);
                _dbContext.SaveChanges();

                result = newToken;
            }
            return result;
        }
    }
}
