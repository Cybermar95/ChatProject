using ApiService.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiService.DataAccessLayer
{
    public class WebApiDBContext : DbContext, IWebApiDBContext
    {
        public DbSet<Messages> Messages { get; set; }
        public DbSet<ChatUsers> ChatUsers { get; set; }

        public WebApiDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}