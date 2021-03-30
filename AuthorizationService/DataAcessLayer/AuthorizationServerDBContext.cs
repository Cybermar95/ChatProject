using AuthorizationService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.DataAcessLayer
{
    public class AuthorizationServerDBContext : DbContext, IAuthorizationServerDBContext
    {
        public DbSet<ChatUsers> ChatUsers { get; set; }

        public  DbSet<AccessTokens> AcessTokens { get; set; }

        public AuthorizationServerDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
