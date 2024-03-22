using BLL.Interfaces;
using BLL.Models.Forms.Message;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageBll _messageBll;
        public ChatHub(IMessageBll messageBll)
        {
            _messageBll = messageBll;
        }

        public async Task SendMessage(AddMessageFormBll message)
        {
            _messageBll.Insert(message);
            await Clients.All.SendAsync("receiveMessage", message);
        }


    }
}
