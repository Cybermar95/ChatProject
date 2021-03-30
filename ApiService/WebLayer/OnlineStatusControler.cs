using ApiService.AccessLayer;
using ApiService.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiService.WebLayer
{
    [Route("API/[controller]")]
    [ApiController]
    public class RoomOnlineStatusController : ControllerBase
    {
        private readonly IRoomManagerService _businessLayer;
        private readonly IAccessManager _accessManager;

        public RoomOnlineStatusController(IRoomManagerService businessLayer, IAccessManager accessManager)
        {
            _businessLayer = businessLayer;
            this._accessManager = accessManager;
        }

        delegate ActionResult<IEnumerable<string>> Operation(int roomID, string name);

        [HttpGet("{roomID}")]
        public ActionResult<IEnumerable<string>> Get(int roomID, [FromQuery] string name)
        {
            Operation operation  = (x, y) => { _businessLayer.UpdateUserStatus(x, y); return _businessLayer.GetOnlineUsers(x);};
        
            var checkAccessResult = _accessManager.CheckAccess(roomID, Request.Headers["AccessToken"]);

            return (checkAccessResult is OkResult)
                    ? operation(roomID, name)
                    : checkAccessResult;
        }
    }
}
