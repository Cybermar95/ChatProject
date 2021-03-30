using ApiService.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiService.AccessLayer
{
    public class AccessManager : IAccessManager
    {
        private readonly OkResult _ok = new();
        private readonly UnauthorizedResult _unauthorized = new();
        private readonly NotFoundResult _notFound = new();
        private readonly ConflictResult _conflict = new();

        private readonly IAccessDBContext _dbContext;
        public AccessManager(IAccessDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult CheckAccess(int roomID, string accessTokenStr)
        {
            ActionResult result;

            if (Guid.TryParse(accessTokenStr, out Guid accessToken))
            {
                var isPublicRoom = IsPublicRoom(roomID);

                if (isPublicRoom is { })
                {
                    var userID = GetUserIDByToken(accessToken);

                    if (userID is { })
                    {
                        result = isPublicRoom.Value || CheckRoomInvitations(roomID, userID.Value)
                                 ? _ok               // Возвращаем 200.
                                 : _unauthorized;    // Возвращаем 401 если не удалось найти пришлашение пользователя в приватную комнате.
                    }
                    else { result = _unauthorized; } // Возвращаем 401 если не удалось найти пользователя с токеном из параметров запроса.
                }
                else { result = _notFound; }         // Возвращаем 404 если не удалось найти комнату из параметров запроса.
            }
            else { result = _conflict; }             // Возвращаем 409 если не удалось распарсить токен.

            return result;
        }

        private bool? IsPublicRoom(int roomID) => _dbContext.ChatRooms.Where(room => room.ID == roomID).FirstOrDefault()?.IsPublic;

        private int? GetUserIDByToken(Guid accessToken) => _dbContext.AcessTokens.Join(_dbContext.ChatUsers,
                                                                            acessTokens => acessTokens.UserID,
                                                                            chatUsers => chatUsers.ID,
                                                                            (acessTokens, chatUsers) => new { acessTokens.Token, chatUsers.ID })
                                                                           .Where(qr => qr.Token == accessToken)
                                                                           .FirstOrDefault()?.ID;

        private bool CheckRoomInvitations(int roomID, int userID) => _dbContext.ChatRoomInvitations.Any(x => x.UserID == userID && x.RoomID == roomID);
    }
}
