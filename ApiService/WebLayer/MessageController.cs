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
        public ActionResult<IEnumerable<Messages>> GetMessages(int roomID, [FromQuery] int lastMessageID, [FromHeader] string accessToken)
        {
                var checkAccessResult = _accessManager.CheckAccess(roomID, accessToken);

                return  (checkAccessResult is OkResult)
                        ? _messageService.GetMessages(lastMessageID)
                        : checkAccessResult;
        }

        [HttpPost("{roomId}")]
        public ActionResult Post(int roomId, [FromBody] MessageFromClient msg, [FromHeader] string accessToken)
        {
            var checkAccessResult = _accessManager.CheckAccess(roomId, accessToken);

            Guid.TryParse(accessToken, out Guid guid);

            Messages message = new();

            message.Text = msg.Text;
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
