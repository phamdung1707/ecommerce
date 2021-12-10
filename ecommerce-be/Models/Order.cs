using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Models
{
    public class Order
    {
        public long id { get; set; }
        public long user_id_buy { get; set; }
        public long product_id { get; set; }
        public int quantity { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public bool isCompleted { get; set; }
        public long user_id_sell { get; set; }
    }
}
