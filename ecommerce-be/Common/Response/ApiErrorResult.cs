using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Common.Response
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            this.status = "error";
            this.message = message;
        }
    }
}
