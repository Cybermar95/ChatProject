using ApiService.BusinessLayer;
using ApiService.DataAccessLayer;
using ApiService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiService.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class RoomOnlineStatusController : ControllerBase
    {
        private readonly IRoomManagerService _businessLayer;

        public RoomOnlineStatusController(IRoomManagerService businessLayer)
        {
            _businessLayer = businessLayer;
        }


        [HttpGet("{roomID}")]
        public ActionResult<IEnumerable<string>> Get(int roomID, [FromQuery] string name)
        {
            _businessLayer.UpdateUserStatus(roomID, name);
            return new ActionResult<IEnumerable<string>>(_businessLayer.GetOnlineUsers(roomID));
        }

    }
}
