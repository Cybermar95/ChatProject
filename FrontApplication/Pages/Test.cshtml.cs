using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontApplication.Pages
{
    public class TestModel : PageModel
    {
        private DemoServerStorage _storage = DemoServerStorage.GetServerStorage(); //singletone call

        public string Message { get; set; }

        public void OnGet()
        {
            _storage.AddMessage($"[{DateTime.Now}]: Chat Started!");
        }

        public void OnPost(string msg)
        {
            _storage.AddMessage(msg);
            Message = _storage.GetMessages();
            //OneMoreMessage += msg;
            //Message = OneMoreMessage;
        }
    }
}
