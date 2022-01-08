using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Models;
using ecommerce_be.Services.Orders;
using ecommerce_be.Services.Orders.Request;

namespace ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var result = await _orderService.Create(request);

            return Ok(result);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _orderService.DeleteOrder(id);

            return Ok(result);
        }

        [HttpGet("buy/{id}")]
        public async Task<IActionResult> GetByUserBuy(long id)
        {
            var result = await _orderService.FindByUserBuyId(id);

            return Ok(result);
        }

        [HttpGet("sell/{id}")]
        public async Task<IActionResult> GetByUserSell(long id)
        {
            var result = await _orderService.FindByUserSellId(id);

            return Ok(result);
        }

    }
}
