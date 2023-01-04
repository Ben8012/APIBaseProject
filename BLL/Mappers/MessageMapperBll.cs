using BLL.Models.DTO;
using BLL.Models.Forms.Message;
using DAL.Models.DTO;
using DAL.Models.Forms.Message;

namespace BLL.Mappers
{
    public static class MessageMapperBll
    {
        internal static MessageBll ToMessageBll(this MessageDal messageDal)
        {
            return new MessageBll()
            {
                Id = messageDal.Id,
                RecieverId = messageDal.RecieverId,
                SenderId = messageDal.SenderId,
                CreatedAt = messageDal.CreatedAt,
                Content = messageDal.Content,
                UpdatedAt = messageDal.UpdatedAt,
                IsActive = messageDal.IsActive,

            };
        }

        internal static AddMessageFormDal ToAddMessageFromDal(this AddMessageFormBll addMessageFromBll)
        {
            return new AddMessageFormDal()
            {
                RecieverId = addMessageFromBll.RecieverId,
                SenderId = addMessageFromBll.SenderId,
                Content = addMessageFromBll.Content,
            };
        }

        internal static UpdateMessageFormDal ToUpdateMessageFormDal(this UpdateMessageFormBll updateMessageFormBll)
        {
            return new UpdateMessageFormDal()
            {
                Id = updateMessageFormBll.Id,
                RecieverId = updateMessageFormBll.RecieverId,
                SenderId = updateMessageFormBll.SenderId,
                Content = updateMessageFormBll.Content,
            };
        }
    }
}
