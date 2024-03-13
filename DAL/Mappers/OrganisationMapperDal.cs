using DAL.Models.DTO;
using System.Data.Common;
using System.Security.Cryptography;

namespace DAL.Mappers
{
    public static class OrganisationMapperDal
    {
        internal static OrganisationDal ToOrganisationDal(this DbDataReader reader)
        {
            return new OrganisationDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                Picture = (string)reader["picture"], 
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                AdressId = (int)reader["adress_Id"],
                Level= (string)reader["level"],
                RefNumber = (string)reader["refNumber"]

            };

        }
    }
}
