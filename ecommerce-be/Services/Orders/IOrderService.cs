using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Orders.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Orders
{
    public interface IOrderService
    {
        Task<ApiResult<Order>> Create(CreateOrderRequest request);
        Task<ApiResult<Order>> Update(Order request);
        Task<ApiResult<Order>> DeleteOrder(long id);
        Task<ApiResult<List<Order>>> FindByUserBuyId(long id);
        Task<ApiResult<List<Order>>> FindByUserSellId(long id);

    }
}
