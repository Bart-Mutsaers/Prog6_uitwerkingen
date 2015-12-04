using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ChatService : IChatService
    {

        public Message[] SendMessage(Message message)
        {
            using (var context = new ChatContext())
            {
                context.ChatMsg.Add(new ChatMsg()
                {
                    Message = message.Content,
                    TimeStamp = DateTime.Now,
                    User = message.User
                });

                context.SaveChanges();
                return GetMessages();
            }
        }

        public Message[] GetMessages()
        {
            using (var context = new ChatContext())
            {
                return context.ChatMsg.
                    OrderByDescending(c => c.TimeStamp)
                    .Take(10)
                    .OrderBy(c => c.TimeStamp)
                    .ToList()
                    .Select(c => new Message(c))
                    .ToArray();
            }
        }
    }
}
