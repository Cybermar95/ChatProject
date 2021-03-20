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

        [HttpGet]
        public MessageRepository Get() => _messageRepository;

        [HttpPost]
        public void Post([FromBody] Message msg)
        {
            msg.Date = DateTime.Now.ToString();
            _messageRepository.AddMessage(msg);
        }
    }
}
