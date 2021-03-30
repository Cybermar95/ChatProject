using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.BusinessLayer
{
    public interface IRoomManagerService
    {
        public void UpdateUserStatus(int roomID, string UserName);

        ActionResult<IEnumerable<string>> GetOnlineUsers(int roomID);
    }
}
