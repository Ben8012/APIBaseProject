using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class MessageMapperDal
    {
        internal static MessageDal ToMessageDal(this DbDataReader reader)
        {
            return new MessageDal()
            {
                Id = (int)reader["Id"],
                SenderId = (int)reader["sender_Id"],
                RecieverId = (int)reader["reciever_Id"],
                Content = (string)reader["content"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
               

            };

        }
    }
}
