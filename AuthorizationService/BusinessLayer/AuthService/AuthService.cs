
using System;
using System.Linq;
using AuthorizationService.DataAcessLayer;
using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.BusinessLayer
{
    public class AuthService : IAuthService
    {
        private readonly IAuthorizationServerDBContext _dbContext;
        private readonly ConflictResult _conflict = new();

        public AuthService(IAuthorizationServerDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public ActionResult<AccessTokens> Authorize(string userName, string password)
        {
            ActionResult<AccessTokens> result = _conflict;

            var user = _dbContext.ChatUsers.FirstOrDefault(user => user.Name == userName && user.Password == password);

            if (user is { })
            {

                // Удаляем старый токен доступа.
                var outdatedTokens = _dbContext.AcessTokens.Where(token => token.UserID == user.ID).ToArray();
                _dbContext.AcessTokens.RemoveRange(outdatedTokens);

                AccessTokens newToken = new()
                {
                    UserID = user.ID,
                    Token = Guid.NewGuid()
                };

                _dbContext.AcessTokens.Add(newToken);
                _dbContext.SaveChanges();
                result = newToken;
            }

            return result;
        }

        public void LogOff(string UserName, Guid Token)
        {
            throw new NotImplementedException();
        }
    }


}