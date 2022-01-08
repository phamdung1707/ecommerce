using ecommerce_be.Models;
using ecommerce_be.Services.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Comments.Response
{
    public class CommentResponse
    {
        public long id { get; set; }
        public long product_id { get; set; }
        public string content { get; set; }
        public DateTime create_date { get; set; }

        public UserResponse user_comment { get; set; }
    }
}
