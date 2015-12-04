using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatService
{
    public class ChatContext : DbContext
    {
        public ChatContext()
            : base("name=ChatDB")
        {

        }
        public DbSet<ChatMsg> ChatMsg { get; set; }
    }
}