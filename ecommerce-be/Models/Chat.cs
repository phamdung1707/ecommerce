using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Models
{
    public class Chat
    {
        public long id { get; set; }
        public long room_id { get; set; }
        public long user_id { get; set; }
        public string content { get; set; }
        public DateTime create_date { get; set; }

    }
}
