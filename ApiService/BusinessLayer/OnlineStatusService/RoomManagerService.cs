using System.Collections.Generic;
using System.Collections.Concurrent;
using ApiService.Model;
using System;
using System.Linq;

namespace ApiService.BusinessLayer
{
    public class RoomManagerService : IRoomManagerService
    {

        // Классика.
        private readonly ConcurrentDictionary<int, ChatRoom> ChatRooms = new ConcurrentDictionary<int, ChatRoom>(new List<KeyValuePair<int, ChatRoom>>() {new KeyValuePair<int, ChatRoom>(1, new ChatRoom())});

        public void UpdateUserStatus(int roomID, string UserName)
        {
            ChatRooms[roomID].RecentOnlineUsers[UserName] = DateTime.Now;
        }

        public IEnumerable<string> GetOnlineUsers(int roomID)
        {
            RefreshRoomUsers(roomID);
            return ChatRooms[roomID].RecentOnlineUsers.Keys;
        }


        private void RefreshRoomUsers(int roomID)
        {
            var room = ChatRooms[roomID].RecentOnlineUsers;
            var deadUsers = room.Where(x => x.Value + TimeSpan.FromSeconds(10) < DateTime.Now);

            deadUsers.ToList().ForEach(x => ChatRooms[roomID].RecentOnlineUsers.Remove(x.Key));
        }


        private void CreateRoom(int RoomID)
        {
            ChatRooms.TryAdd(RoomID, new ChatRoom());
        }

    }
}
