using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ApiService.DataAccessLayer
{
    public class WebApiDBContext : DbContext, IWebApiDBContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }

        public WebApiDBContext(DbContextOptions options) : base(options)
        {
        }
    }

    public interface IWebApiDBContext
    {
        DbSet<Message> Messages { get; set; }
        DbSet<ChatUser> ChatUsers { get; set; }

        int SaveChanges();
    }
}