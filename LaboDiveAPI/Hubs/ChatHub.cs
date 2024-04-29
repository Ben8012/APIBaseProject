
using API.Mappers;
using API.Models.DTO;
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
            Message messageTosend = _messageBll.Insert(message).ToMessage();
            await Clients.All.SendAsync("ReceiveMessage", messageTosend);
        }

        public async Task DeleteMessage(DeleteMessageFormBll message)
        {
            _messageBll.Delete(message.Id);
            await Clients.All.SendAsync("MessageDeleted", message);
        }

        //public async Task SendMessageToGroup(Message message, string groupName)
        //{
        //    await Clients.Group(groupName).SendAsync("fromGroup" + groupName, message);
        //}

        //public async Task JoinGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //    await SendMessageToGroup(
        //        new Message
        //        {

        //            Sender = "System",
        //            Time = DateTime.Now,
        //            Content = Context.ConnectionId + " has joined " + groupName,
        //        }
        //        , groupName);
        //}


    }
}
