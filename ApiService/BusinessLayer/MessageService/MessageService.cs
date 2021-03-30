using ApiService.DataAccessLayer;
using ApiService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiService.BusinessLayer
{
    public class MessageService : IMessageService
    {
        private readonly IWebApiDBContext _dbContext;
        private readonly OkResult _ok = new();

        public MessageService(IWebApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult AddMessage(Messages message)
        {
            message.Date = DateTime.Now;
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return _ok;
        }
        public ActionResult<IEnumerable<Messages>> GetMessages(int id) => new(_dbContext.Messages.Where(msg => msg.ID > id).ToArray());
    }
}