using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Model
{
    public class MessageRepository
    {
        #region Singleton

        private static MessageRepository _singleton;
        private MessageRepository(){}

        public static MessageRepository GetMessageRepository()
        {
            if(_singleton == null)
            {
                _singleton = new MessageRepository();
            }

            return _singleton;
        }

        #endregion



        private readonly List<Message> _messages = new();

        public void AddMessage(Message message) => _messages.Add(message);
        public IEnumerable<Message> GetMessage(int MsgId) => _messages.Where(msg => msg.ID > MsgId);

        public int GetNewId() => _messages.Count;
    }
}
