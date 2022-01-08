using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Models;
using ecommerce_be.Services.Chats;
using ecommerce_be.Services.Chats.Request;

namespace ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateChatRequest request)
        {
            var result = await _chatService.Create(request);

            return Ok(result);
        }

        [HttpGet("room/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _chatService.GetByRoomId(id);

            return Ok(result);
        }
    }
}
