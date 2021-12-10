using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Common.Response
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult()
        {
        }

        public ApiSuccessResult(string message)
        {
            this.status = "success";
            this.message = message;
        }

        public ApiSuccessResult(string message, T data)
        {
            this.status = "success";
            this.message = message;
            this.data = data;
        }
    }
}
