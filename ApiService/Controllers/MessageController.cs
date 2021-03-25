using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;
using ApiService.DataAccessLayer;

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
        public ActionResult<IEnumerable<Message>> Get(int id, [FromBody] AcessToken token)
        {
            ActionResult<IEnumerable<Message>> result;

            if(_businessLayer.IsAuthorised(token))
            {
                var messages = _businessLayer.GetMessages(id);
                result = new ActionResult<IEnumerable<Message>>(messages);
            }
            else
            {
                result = Unauthorized();
            }

            return result;
        }

        [HttpPost]
        public Message Post([FromBody] Message message) => _businessLayer.AddMessage(message);
    }
}
