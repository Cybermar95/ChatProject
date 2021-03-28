using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;


namespace ApiService.Model
{
    public class ChatRoom
    {
        public readonly Dictionary<string, DateTime> RecentOnlineUsers = new Dictionary<string, DateTime>();
    }
}
