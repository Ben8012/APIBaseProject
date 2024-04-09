
using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class ClubMapperDal
    {
        internal static ClubDal ToClubDal(this DbDataReader reader)
        {
            return new ClubDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                CreatorId = (int)reader["creator_id"], 
                AdressId = reader["adress_id"] is DBNull ? 0 : (int)reader["adress_id"]
            };

        }
    }
}
