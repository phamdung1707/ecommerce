using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Orders.Request
{
    public class CreateOrderRequest
    {
        public long user_id_buy { get; set; }
        public long product_id { get; set; }
        public int quantity { get; set; }
        public bool isCompleted { get; set; }
        public long user_id_sell { get; set; }
    }
}
