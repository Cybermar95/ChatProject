using ApiService.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiService.DataAccessLayer
{
    public class AccessDBContext : DbContext, IAccessDBContext
    {
        public DbSet<ChatUsers> ChatUsers { get; set; }
        public DbSet<ChatRoomInvitations> ChatRoomInvitations { get; set; }
        public DbSet<AccessTokens> AcessTokens { get; set; }

        public DbSet<ChatRooms> ChatRooms { get; set; }

        public AccessDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
