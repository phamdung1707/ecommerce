using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Comments.Request
{
    public class CreateCommentRequest
    {
        public long product_id { get; set; }
        public long user_id { get; set; }
        public string content { get; set; }
        public DateTime create_date { get; set; }
    }
}
