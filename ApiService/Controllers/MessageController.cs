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
        public IEnumerable<Message> Get(int id) => _businessLayer.GetMessages(id);

        [HttpPost]
        public Message Post([FromBody] Message message) => _businessLayer.AddMessage(message);
    }
}
