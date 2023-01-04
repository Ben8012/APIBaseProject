using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class InsuranceMapperDal
    {
        internal static InsuranceDal ToInsuranceDal(this DbDataReader reader)
        {
            return new InsuranceDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                Picture = reader["picture"] is DBNull ? null : (string)reader["picture"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                AdressId = (int)reader["adress_id"],
               
            };

        }
    }
}
