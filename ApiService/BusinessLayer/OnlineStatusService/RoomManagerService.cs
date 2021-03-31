using System.Collections.Generic;
using System.Collections.Concurrent;
using ApiService.Model;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.BusinessLayer
{
    public class RoomManagerService : IRoomManagerService
    {

        // Классика.
        private readonly ConcurrentDictionary<int, ChatRoomOnlineCache> ChatRooms = new ConcurrentDictionary<int, ChatRoomOnlineCache>(new List<KeyValuePair<int, ChatRoomOnlineCache>>() {new KeyValuePair<int, ChatRoomOnlineCache>(1, new ChatRoomOnlineCache())});

        public void UpdateUserStatus(int roomID, string userName)
        {
            ChatRooms[roomID].RecentOnlineUsers[userName] = DateTime.Now;
        }

        public ActionResult<IEnumerable<string>> GetOnlineUsers(int roomID)
        {
            RefreshRoomUsers(roomID);
            return new(ChatRooms[roomID].RecentOnlineUsers.Keys);
        }


        private void RefreshRoomUsers(int roomID)
        {
            var room = ChatRooms[roomID].RecentOnlineUsers;
            var deadUsers = room.Where(x => x.Value + TimeSpan.FromSeconds(10) < DateTime.Now);

            deadUsers.ToList().ForEach(x => ChatRooms[roomID].RecentOnlineUsers.Remove(x.Key));
        }


        private void CreateRoom(int RoomID)
        {
            ChatRooms.TryAdd(RoomID, new ChatRoomOnlineCache());
        }

    }
}
