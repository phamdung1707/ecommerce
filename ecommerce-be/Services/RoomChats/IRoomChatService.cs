using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.RoomChats.Request;
using ecommerce_be.Services.RoomChats.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.RoomChats
{
    public interface IRoomChatService
    {
        Task<ApiResult<RoomChat>> Create(CreateRoomChatRequest request);
        Task<ApiResult<List<RoomChatResponse>>> GetByUserId(long id);

    }
}
