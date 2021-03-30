using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.AccessLayer
{
    public interface IAccessManager
    {
        /// <summary>
        /// Проверяет доступ пользователя к чат комнате.
        /// </summary>
        /// <param name="roomId">Идентификатор комнаты.</param>
        /// <param name="accessToken">Токен доступа пользователя.</param>
        ActionResult CheckAccess(int roomID, string accessToken);
    }
}
