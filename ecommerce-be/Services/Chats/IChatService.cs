using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Chats.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Chats
{
    public interface IChatService
    {
        Task<ApiResult<Chat>> Create(CreateChatRequest request);
        Task<ApiResult<List<Chat>>> GetByRoomId(long id);
        Task<Chat> GetLastChatByRoomId(long id);
    }
}
