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
                Picture = (string)reader["picture"],
                Map = (string)reader["map"],
                Description = reader["description"] is DBNull ? null : (string)reader["description"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                AdressId = (int)reader["adress_id"],
            };

        }
    }
}
