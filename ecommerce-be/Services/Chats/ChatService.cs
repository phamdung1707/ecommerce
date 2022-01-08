using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Chats.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Hubs;
using ecommerce_be.Services.Chats.Response;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR;

namespace ecommerce_be.Services.Chats
{
    public class ChatService : IChatService
    {
        public readonly EcommerceDbContext _context;

        public ChatService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<Chat>> Create(CreateChatRequest request)
        {
            var roomChat = await _context.RoomChats.FindAsync(request.room_id);

            if (roomChat == null)
            {
                return new ApiErrorResult<Chat>("Không tìm thấy phòng chat");
            }

            Chat chat = new Chat()
            {
                room_id = request.room_id,
                content = request.content,
                user_id = request.user_id,
                create_date = DateTime.Now
            };

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            var response = await _context.Chats.FirstOrDefaultAsync(c => c.room_id == chat.room_id && c.create_date == chat.create_date && c.user_id == chat.user_id);

            long userId = roomChat.user_one_id;
            if (chat.user_id == roomChat.user_one_id)
            {
                userId = roomChat.user_two_id;
            }           

            return new ApiSuccessResult<Chat>("Tạo chat thành công", response);
        }

        public async Task<ApiResult<List<Chat>>> GetByRoomId(long id)
        {
            var roomChat = await _context.RoomChats.FindAsync(id);

            if (roomChat == null)
            {
                return new ApiErrorResult<List<Chat>>("Không tìm thấy phòng chat");
            }

            var response = await _context.Chats.Where(c => c.room_id == id).ToListAsync();

            return new ApiSuccessResult<List<Chat>>("Lấy danh sách tin nhắn thành công", response);
        }

        public async Task<Chat> GetLastChatByRoomId(long id)
        {
            var roomChat = await _context.RoomChats.FindAsync(id);

            if (roomChat == null)
            {
                return null;
            }

            var response = await _context.Chats.Where(c => c.room_id == id).ToListAsync();

            if (response.Count > 0)
            {
                Chat chat = response[0];

                for (int i = 1; i < response.Count; i++)
                {
                    if (chat.create_date < response[i].create_date)
                    {
                        chat = response[i];
                    }
                }

                return chat;
            }

            return null;
        }
    }
}
