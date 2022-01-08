using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Models;
using ecommerce_be.Services.RoomChats;
using ecommerce_be.Services.RoomChats.Request;

namespace ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomChatsController : ControllerBase
    {
        private readonly IRoomChatService _roomChatService;

        public RoomChatsController(IRoomChatService roomChatService)
        {
            _roomChatService = roomChatService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoomChatRequest request)
        {
            var result = await _roomChatService.Create(request);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _roomChatService.GetByUserId(id);

            return Ok(result);
        }
    }
}
