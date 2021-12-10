using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Models
{
    public class RoomChat
    {
        public long id { get; set; }
        public long user_one_id { get; set; }
        public long user_two_id { get; set; }
    }
}
