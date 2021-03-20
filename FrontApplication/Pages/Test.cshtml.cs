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
        }

        public void OnPost(string msg, string chatName)
        {
            _storage.AddMessage($"[{DateTime.Now}] {chatName}: {msg}\n");
            Message = _storage.GetMessages();
        }

        public string SendLastMessage(string lastMessageID)
        {
            return DateTime.Now.ToString();
        }
    }
}
