using ApiService.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiService.DataAccessLayer
{
    public interface IWebApiDBContext
    {
        DbSet<Messages> Messages { get; set; }
        DbSet<ChatUsers> ChatUsers { get; set; }

        int SaveChanges();
    }
}