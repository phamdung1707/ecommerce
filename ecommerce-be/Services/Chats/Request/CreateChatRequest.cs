using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Chats.Request
{
    public class CreateChatRequest
    {
        public long room_id { get; set; }
        public long user_id { get; set; }
        public string content { get; set; }
    }
}
