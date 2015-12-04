using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ChatService
{
    /**
     * De klasse die we gebruiken met entity framework 
     */
    public class ChatMsg
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }

        public string User { get; set; }

    }
}
