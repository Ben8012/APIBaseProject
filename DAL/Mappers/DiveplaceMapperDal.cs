using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class DiveplaceMapperDal
    {
        internal static DiveplaceDal ToDiveplaceDal(this DbDataReader reader)
        {
            return new DiveplaceDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],             
                GuidImage = reader["guidImage"] is DBNull ? null : (string)reader["guidImage"],
                GuidMap = reader["guidMap"] is DBNull ? null : (string)reader["guidMap"],
                Description = reader["description"] is DBNull ? null : (string)reader["description"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                AdressId = reader["adress_id"] is DBNull ? 0 : (int)reader["adress_id"],
                Gps = reader["gps"] is DBNull ? null : (string)reader["gps"],
                MaxDepp = (int)reader["maxDepp"],
                Price = (double)reader["price"],
                Compressor = (bool)reader["compressor"],
                Restoration = (bool)reader["restoration"],
                Url = reader["url"] is DBNull ? null : (string)reader["url"],
                CreatorId = (int)reader["creator_Id"]
                
            };

        }
    }
}