using API.Models.DTO;
using API.Models.Forms.Insurance;
using API.Models.Forms.Message;
using BLL.Models.DTO;
using BLL.Models.Forms.Insurance;
using BLL.Models.Forms.Message;

namespace API.Mappers
{
    public static class MessageMapperAPI
    {
        internal static Message ToMessage(this MessageBll messageBll)
        {
            return new Message()
            {
                Id= messageBll.Id,
                Reciever= messageBll.Reciever is null ? null : messageBll.Reciever.ToUser(),
                Sender= messageBll.Sender is null ? null : messageBll.Sender.ToUser(),
                CreatedAt= messageBll.CreatedAt,
                Content= messageBll.Content,
                UpdatedAt= messageBll.UpdatedAt,
                IsActive= messageBll.IsActive,

            };
        }

        internal static AddMessageFormBll ToAddMessageFromBll(this AddMessageForm addMessageFrom)
        {
            return new AddMessageFormBll()
            {
                RecieverId= addMessageFrom.RecieverId,
                SenderId= addMessageFrom.SenderId,
                Content= addMessageFrom.Content,    
            };
        }

        internal static UpdateMessageFormBll ToUpdateMessageFormBll(this UpdateMessageForm updateMessageForm)
        {
            return new UpdateMessageFormBll()
            {
                Id= updateMessageForm.Id,
                RecieverId = updateMessageForm.RecieverId,
                SenderId = updateMessageForm.SenderId,
                Content = updateMessageForm.Content,
            };
        }
    }
}
