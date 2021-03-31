using System;
using System.Collections.Generic;


namespace ApiService.Model
{
    public class ChatRoomOnlineCache
    {
        public readonly Dictionary<string, DateTime> RecentOnlineUsers = new ();
    }
}
