using ApiService.AccessLayer;
using ApiService.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
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
            _accessManager = accessManager;
        }




        [HttpGet("{roomID}")]
        public ActionResult<IEnumerable<string>> Get(int roomID, [FromHeader] string accessToken)
        {
            ActionResult<IEnumerable<string>> result;

            var checkAccessResult = _accessManager.CheckAccess(roomID, accessToken);


            if (accessToken is null)
                return NotFound();


            var userID = _accessManager.GetUserIDByToken(Guid.Parse(accessToken));
            


            if (userID is { })
            {

                var userName = _accessManager.GetUserNameById(userID.Value);


                if (checkAccessResult is OkResult)
                {
                    _businessLayer.UpdateUserStatus(roomID, userName);
                    result = _businessLayer.GetOnlineUsers(roomID);
                }
                else
                {
                    result = checkAccessResult;
                }
            }
            else
            {
                result = Conflict();
            }

            return result;
        }
    }
}
