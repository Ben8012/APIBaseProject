
using API.Mappers;
using API.Models.DTO;
using API.Models.DTO.UserAPI;
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
            List<Message> messages = _messageBll.GetMessagesBetween(message.SenderId,message.RecieverId).Select(m => m.ToMessage()).ToList();
            var MessageToReturn = new {
                Messages = messages,
                SenderId = message.SenderId,
                RecieverId = message.RecieverId,

            };
            await Clients.All.SendAsync("ReceiveMessage", MessageToReturn);
        }

        public async Task DeleteMessage(DeleteMessageFormBll message)
        {
            _messageBll.Delete(message.Id);
            List<Message> messages = _messageBll.GetMessagesBetween(message.SenderId, message.RecieverId).Select(m => m.ToMessage()).ToList();
            var MessageToReturn = new {
                Messages = messages,
                SenderId = message.SenderId,
                RecieverId = message.RecieverId,

            };
            await Clients.All.SendAsync("MessageDeleted", MessageToReturn);
        }

        public async Task MessageIsRead(IsReadMessageFormBll message)
        {
            _messageBll.IsRead(message.FriendId, message.UserId);
            await Clients.All.SendAsync("MessageReaded", message);
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
