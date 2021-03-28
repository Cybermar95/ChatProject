using ApiService.DataAccessLayer;
using ApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiService.BusinessLayer
{
    public class MessageService : IMessageService
    {
        private readonly IWebApiDBContext _dbContext;
        public MessageService(IWebApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Message AddMessage(Message message)
        {
            message.Date = DateTime.Now;
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();

            return message;
        }


        public IEnumerable<Message> GetMessages(int id) => _dbContext.Messages.Where(msg => msg.ID > id).ToArray();

        public bool IsAuthorised(Guid token) => _dbContext.ChatUsers.Where(x => x.Token == token).AsEnumerable().Any();
    }
}