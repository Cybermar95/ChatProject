using ApiService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.DataAccessLayer
{
    public interface IMessageService
    {
        IEnumerable<Message> GetMessages(int id);

        Message AddMessage(Message message);
        bool IsAuthorised(AcessToken token);
    }

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

        public bool IsAuthorised(AcessToken token)
        {

            return _dbContext.ChatUsers.Where(x => x.Name == token.Name && x.Token == token.Token).AsEnumerable().Any();
        }
    }
}