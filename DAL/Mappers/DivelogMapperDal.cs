using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class DivelogMapperDal
    {
        internal static DivelogDal ToDivelogDal(this DbDataReader reader)
        {
            return new DivelogDal()
            {
                Id = (int)reader["Id"],
                Description = reader["description"] is DBNull ? null : (string)reader["description"],
                Duration = (int)reader["duration"],
                MaxDeep = (int)reader["maxDeep"],
                AirTemperature = reader["airTemperature"] is DBNull ? 0 : (int)reader["airTemperature"],
                WaterTemperature = reader["waterTemperature"] is DBNull ? 0 : (int)reader["waterTemperature"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                UserId = (int)reader["user_Id"],
                EventId = reader["event_Id"] is DBNull ? 0 : (int)reader["event_Id"]
            };

        }
    }
}
