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
        public DbSet<ChatUser> ChatUsers { get; set; }

        public AuthorizationServerDBContext(DbContextOptions options) : base(options)
        {
        }
    }

    public interface IAuthorizationServerDBContext
    {
        DbSet<ChatUser> ChatUsers { get; set; }

        int SaveChanges();
    }
}
