using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Products.Requests
{
    public class CreateProductRequest
    {
        public string title_name { get; set; }
        public string images { get; set; }
        public string colors { get; set; }
        public long price { get; set; }
        public string type { get; set; }
        public bool isFavorite { get; set; }
        public bool isPopular { get; set; }
        public string description { get; set; }
        public long user_id { get; set; }
    }
}
