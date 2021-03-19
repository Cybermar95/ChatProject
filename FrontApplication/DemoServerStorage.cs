using System;
using System.Collections.Generic;


namespace FrontApplication.Pages
{
    public class DemoServerStorage
    {
        private DemoServerStorage() { }
        private static DemoServerStorage _demoServerStorage;
        public static DemoServerStorage GetServerStorage()
        {
            if (_demoServerStorage == null)
            {
                _demoServerStorage = new DemoServerStorage();
            }
            return _demoServerStorage;
        }

        private readonly List<string> _chatHistory = new List<string>();
  
        public void AddMessage(string msg) => _chatHistory.Add(msg);

        public string GetMessages() => String.Join('\n', _chatHistory);
       
    }
}
