using AuthorizationService.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.DataAcessLayer
{
    public interface IAuthorizationServerDBContext
    {
        DbSet<ChatUsers> ChatUsers { get; set; }

        DbSet<AccessTokens> AcessTokens { get; set; }

        int SaveChanges();
    }
}
