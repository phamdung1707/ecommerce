using ecommerce_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Chats.Response
{
    public class ChatHubResponse
    {
        public long userId { get; set; }
        public Chat chat { get; set; }
    }
}
