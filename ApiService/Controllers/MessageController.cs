using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;

namespace ApiService.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private MessageRepository _messageRepository = MessageRepository.GetMessageRepository();

        [HttpGet ("{id}")]
        public IEnumerable<Message> Get(int id) => _messageRepository.GetMessage(id);

        [HttpPost]
        public Message Post([FromBody] Message message)
        {

            HttpContext
            message.ID = _messageRepository.GetNewId();
            _messageRepository.AddMessage(message);
            return message;
        }
    }
}
