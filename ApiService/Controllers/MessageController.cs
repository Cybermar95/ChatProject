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
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _businessLayer;

        public MessageController(IMessageService businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Message>> GetMessages(int id)
        {
            ActionResult<IEnumerable<Message>> result;
            try
            {
                Guid.TryParse(Request.Headers["AccessToken"], out Guid accessToken);
                if (_businessLayer.IsAuthorised(accessToken))
                {
                    var messages = _businessLayer.GetMessages(id);
                    result = new ActionResult<IEnumerable<Message>>(messages);
                }
                else
                {
                    result = Unauthorized();
                }

            }
            catch
            {
                //TODO 
                result = Unauthorized();
            }

            return result;
        }

        [HttpPost]
        public Message Post([FromBody] Message message) => _businessLayer.AddMessage(message);
    }
}
