﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Users.Request
{
    public class LoginRequest
    {
        public string phone { get; set; }
        public string password { get; set; }
    }
}
