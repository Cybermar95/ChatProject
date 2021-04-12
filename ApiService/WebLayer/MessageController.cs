using ApiService.AccessLayer;
using ApiService.BusinessLayer;
using ApiService.Model;
using ApiService.Model.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiService.WebLayer
{
    [Route("API/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IAccessManager _accessManager;


        public MessageController(IMessageService messageService, IAccessManager accessManager)
        {
            this._messageService = messageService;
            this._accessManager = accessManager;
        }

        [HttpGet("{roomId}")]
        public ActionResult<IEnumerable<Messages>> GetNewMessages([FromHeader] string accessToken, int roomID, [FromQuery] int msgID)
        {
                var checkAccessResult = _accessManager.CheckAccess(roomID, accessToken);

                return  (checkAccessResult is OkResult)
                        ? _messageService.GetNewMessages(roomID, msgID)
                        : checkAccessResult;
        }

        [HttpGet("{roomId}/history")]
        public ActionResult<IEnumerable<Messages>> GetOldMessages([FromHeader] string accessToken, int roomID, [FromQuery] int msgID)
        {
            var checkAccessResult = _accessManager.CheckAccess(roomID, accessToken);

            return (checkAccessResult is OkResult)
                    ? _messageService.GetOldMessages(roomID, msgID)
                    : checkAccessResult;
        }








        [HttpPost("{roomId}")]
        public ActionResult Post(int roomId, [FromBody] ClientMsg clientMsg, [FromHeader] string accessToken)
        {
            var checkAccessResult = _accessManager.CheckAccess(roomId, accessToken);

            Guid.TryParse(accessToken, out Guid guid);

            Messages message = new();

            message.Text = clientMsg.Text;
            message.RoomID = roomId;
            message.Date = DateTime.Now;
            message.UserID = _accessManager.GetUserIDByToken(guid).Value;
            message.UserName = _accessManager.GetUserNameById(message.UserID);



            return (checkAccessResult is OkResult)
                    ? _messageService.AddMessage(message)
                    : checkAccessResult;
        }
    }
}
