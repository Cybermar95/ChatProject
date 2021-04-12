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
        public ActionResult<IEnumerable<Messages>> GetNewMessages(int roomID, int msgId) => new(_dbContext.Messages.Where(msg => msg.RoomID == roomID && msg.ID > msgId)
                                                                                                                   .ToArray()
                                                                                               );
        public ActionResult<IEnumerable<Messages>> GetOldMessages(int roomID, int msgId) 
            => new(_dbContext.Messages.Where(msg => msg.RoomID == roomID && msg.ID < msgId)                                                                                                                   
                                      .OrderByDescending(x => x.ID)                                                                                                              
                                      .Take(50)                                                                                                                  
                                      .ToArray()                                                                                
                  );
    }
}