using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.RoomChats.Request
{
    public class CreateRoomChatRequest
    {
        public long user_one_id { get; set; }
        public long user_two_id { get; set; }
    }
}
