using ecommerce_be.Services.Chats;
using ecommerce_be.Services.Chats.Request;
using ecommerce_be.Services.Chats.Response;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Hubs
{
    public class AppHub : Hub
    {
        private readonly IChatService _chatService;

        public AppHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public override Task OnConnectedAsync()
        {
            /*if (ChatService.appHub == null)
            {
                ChatService.appHub = this;
            }*/
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string data)
        {
            string[] vs = data.Split('|');
            CreateChatRequest request = new CreateChatRequest() {
                room_id = long.Parse(vs[0]),
                user_id = long.Parse(vs[1]),
                content = vs[2]
            };

            var result = await _chatService.Create(request);

            long userId = request.user_id;
            /*if (chat.user_id == roomChat.user_one_id)
            {
                userId = roomChat.user_two_id;
            }*/

            if (result.data != null)
            {
                ChatHubResponse chatHubResponse = new ChatHubResponse()
                {
                    userId = userId,
                    chat = result.data
                };

                string res = JsonConvert.SerializeObject(chatHubResponse);

                await Clients.All.SendAsync("ReceiveMessage", res);

                Console.WriteLine(res);

            }       
        }
    }
}
