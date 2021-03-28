using ApiService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.BusinessLayer
{
    public interface IMessageService
    {
        IEnumerable<Message> GetMessages(int id);

        Message AddMessage(Message message);
        bool IsAuthorised(Guid token);
    }
}