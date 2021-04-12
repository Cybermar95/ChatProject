using ApiService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiService.BusinessLayer
{
    public interface IMessageService
    {
        public ActionResult<IEnumerable<Messages>> GetNewMessages(int roomID, int msgId);
        public ActionResult<IEnumerable<Messages>> GetOldMessages(int roomID, int msgId);
        ActionResult AddMessage(Messages message);
    }
}