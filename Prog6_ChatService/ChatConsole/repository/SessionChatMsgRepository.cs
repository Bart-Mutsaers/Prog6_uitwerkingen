using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatConsole.repository
{
    public class SessionChatMsgRepository : ChatDomain.repository.IChatMsgRepository
    {
        public ChatDomain.ChatMsg GetAll()
        {
           
        }

        public ChatDomain.ChatMsg Add(ChatDomain.ChatMsg chatMsg)
        {
            throw new NotImplementedException();
        }
    }
}
