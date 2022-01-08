using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.RoomChats.Request;
using ecommerce_be.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Services.RoomChats.Response;
using ecommerce_be.Services.Chats;

namespace ecommerce_be.Services.RoomChats
{
    public class RoomChatService : IRoomChatService
    {
        public readonly EcommerceDbContext _context;

        private readonly IUserService _userService;

        private readonly IChatService _chatService;

        public RoomChatService(EcommerceDbContext context, IUserService userService, IChatService chatService)
        {
            _context = context;
            _userService = userService;
            _chatService = chatService;
        }

        public async Task<ApiResult<RoomChat>> Create(CreateRoomChatRequest request)
        {
            var roomChats = await _context.RoomChats.Where(rc => (rc.user_one_id == request.user_one_id && rc.user_two_id == request.user_two_id) 
            || (rc.user_one_id == request.user_two_id && rc.user_two_id == request.user_one_id)).ToListAsync();

            if (roomChats.Count > 0)
            {
                return new ApiErrorResult<RoomChat>("Đã tồn tại");
            }

            RoomChat roomChat = new RoomChat()
            {
                user_one_id = request.user_one_id,
                user_two_id = request.user_two_id
            };

            _context.RoomChats.Add(roomChat);

            await _context.SaveChangesAsync();

            var response = await _context.RoomChats.FirstOrDefaultAsync(rc => rc.user_one_id == roomChat.user_one_id && rc.user_two_id == roomChat.user_two_id);

            return new ApiSuccessResult<RoomChat>("Tạo room chat thành công", response);
        }

        public async Task<ApiResult<List<RoomChatResponse>>> GetByUserId(long id)
        {
            var roomChats = await _context.RoomChats.Where(rc => (rc.user_one_id == id || rc.user_two_id == id)).ToListAsync();

            List<RoomChatResponse> roomChatResponses = new List<RoomChatResponse>();

            foreach (var item in roomChats)
            {
                RoomChatResponse roomChatResponse = new RoomChatResponse()
                {
                    id = item.id,
                    user_chat = await _userService.GetUserById(item.user_one_id == id ? item.user_two_id : item.user_one_id),
                    last_chat = await _chatService.GetLastChatByRoomId(item.id)
                };

                roomChatResponses.Add(roomChatResponse);
            }

            for (int i = 0; i < roomChatResponses.Count; i++)
            {
                for (int j = i + 1; j < roomChatResponses.Count; j++)
                {
                    if ((roomChatResponses[i].last_chat != null && roomChatResponses[j].last_chat != null 
                        && roomChatResponses[i].last_chat.create_date < roomChatResponses[j].last_chat.create_date)
                        || (roomChatResponses[i].last_chat == null && roomChatResponses[j].last_chat != null))
                    {
                        RoomChatResponse tmp = roomChatResponses[i];
                        roomChatResponses[i] = roomChatResponses[j];
                        roomChatResponses[j] = tmp;
                    }
                }
            }

            return new ApiSuccessResult<List<RoomChatResponse>>("Lấy danh sách chat thành công", roomChatResponses);
        }
    }
}
