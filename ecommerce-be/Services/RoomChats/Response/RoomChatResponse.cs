using ecommerce_be.Models;
using ecommerce_be.Services.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.RoomChats.Response
{
    public class RoomChatResponse
    {
        public long id { get; set; }

        public UserResponse user_chat { get; set; }

        public Chat last_chat { get; set; }
    }
}
