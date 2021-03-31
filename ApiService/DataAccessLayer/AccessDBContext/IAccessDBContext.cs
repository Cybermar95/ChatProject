using ApiService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.DataAccessLayer
{
    public interface IAccessDBContext
    {
        DbSet<ChatUsers> ChatUsers { get; set; }
        DbSet<ChatRoomInvitations> ChatRoomInvitations { get; set; }

        DbSet<ChatRooms> ChatRooms { get; set; }

        DbSet<AccessTokens> AcessTokens { get; set; }
        
    }
}
