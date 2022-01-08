using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Orders.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Orders
{
    public class OrderService : IOrderService
    {
        public readonly EcommerceDbContext _context;

        public OrderService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<Order>> Create(CreateOrderRequest request)
        {
            var orders = await _context.Orders.Where(order => order.user_id_buy == request.user_id_buy && order.product_id == request.product_id && order.isCompleted).ToListAsync();

            if (orders.Count > 0)
            {
                return new ApiErrorResult<Order>("Đơn hàng đã tồn tại");
            }

            Order order = new Order()
            {
                user_id_buy = request.user_id_buy,
                product_id = request.product_id,
                quantity = request.quantity,
                create_date = DateTime.Now,
                update_date = DateTime.Now,
                isCompleted = request.isCompleted,
                user_id_sell = request.user_id_sell
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            var response = await _context.Orders.FirstOrDefaultAsync(order => order.user_id_buy == request.user_id_buy && order.product_id == request.product_id && !order.isCompleted);

            return new ApiSuccessResult<Order>("Tạo đơn hàng thành công", response);
        }

        public async Task<ApiResult<Order>> Update(Order request)
        {
            var order = await _context.Orders.FindAsync(request.id);

            if (order == null)
            {
                return new ApiErrorResult<Order>("Đơn hàng không tồn tại");
            }

            order.user_id_buy = request.user_id_buy;
            order.product_id = request.product_id;
            order.quantity = request.quantity;
            order.update_date = DateTime.Now;
            order.isCompleted = request.isCompleted;
            order.user_id_sell = request.user_id_sell;

            _context.Orders.Update(order);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<Order>("Cập nhật đơn hàng thành công", order);
        }

        public async Task<ApiResult<Order>> DeleteOrder(long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.id == id);

            if (order == null)
            {
                return new ApiErrorResult<Order>("Đơn hàng không tồn tại");
            }

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<Order>("Xóa đơn hàng thành công", null);
        }

        public async Task<ApiResult<List<Order>>> FindByUserBuyId(long id)
        {
            var orders = await _context.Orders.Where(o => o.user_id_buy == id).ToListAsync();

            return new ApiSuccessResult<List<Order>>("Lấy danh sách đơn hàng thành công", orders);
        }

        public async Task<ApiResult<List<Order>>> FindByUserSellId(long id)
        {
            var orders = await _context.Orders.Where(o => o.user_id_sell == id).ToListAsync();

            return new ApiSuccessResult<List<Order>>("Lấy danh sách đơn hàng thành công", orders);
        }
    }
}
