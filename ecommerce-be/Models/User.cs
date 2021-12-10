using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Models
{
    public class User
    {
        public long id { get; set; }
        public string username { get; set; }
        public string gmail { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public bool isSeller { get; set; }
    }
}
