using ApiService.AccessLayer;
using ApiService.BusinessLayer;
using ApiService.Model;
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
        public ActionResult<IEnumerable<Messages>> GetMessages(int roomID, [FromQuery] int lastMessageID)
        {
                var checkAccessResult = _accessManager.CheckAccess(roomID, Request.Headers["AccessToken"]);

                return  (checkAccessResult is OkResult)
                        ? _messageService.GetMessages(lastMessageID)
                        : checkAccessResult;
        }

        [HttpPost("{roomId}")]
        public ActionResult Post(int roomId, [FromBody] Messages message)
        {
            var checkAccessResult = _accessManager.CheckAccess(roomId, Request.Headers["AccessToken"]);

            return (checkAccessResult is OkResult)
                    ? _messageService.AddMessage(message)
                    : checkAccessResult;
        }
    }
}
