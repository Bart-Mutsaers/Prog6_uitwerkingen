using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ChatService.IChatService service = new ChatService.ChatServiceClient();

            Console.WriteLine("What is you're name?");
            String name = Console.ReadLine();


            Console.WriteLine("Loading messages...");

            ChatService.Message[] messages = service.GetMessages();
            PrintMessages(messages);

            String line = Console.ReadLine();
            while (!line.Equals("exit"))
            {
                ChatService.Message message = new ChatService.Message()
                {
                    Content = line,
                    User = name,
                };
                messages = service.SendMessage(message);
                PrintMessages(messages);
                line = Console.ReadLine();


            }
        }

        public static void PrintMessages(ChatService.Message[] messages)
        {
            Console.Clear();
            for (int index = 0; index < messages.Length; index++ )
            {
                Console.WriteLine(messages[index].User + ": " + messages[index].Content);
            }
            Console.WriteLine("*** type your'e message ***");
        }
    }
}
