using ApiService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiService.BusinessLayer
{
    public interface IMessageService
    {
        ActionResult<IEnumerable<Messages>> GetMessages(int id);

        ActionResult AddMessage(Messages message);
    }
}