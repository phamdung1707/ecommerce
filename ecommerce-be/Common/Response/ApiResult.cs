using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Common.Response
{
    [Serializable]
    public class ApiResult<T>
    {
        public string status { get; set; }

        public string message { get; set; }

        public T data { get; set; }
    }
}
