using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class UserMapperDal
    {
        internal static UserDal ToUserDal(this DbDataReader reader)
        {
            return new UserDal()
            {
                Id = (int)reader["Id"],
                FirstName = (string)reader["firstname"],
                LastName = (string)reader["lastname"],
                Email = (string)reader["email"],
                Phone = reader["phone"] is DBNull ? null : (string)reader["phone"],
                Role = (string)reader["role"],
                Birthdate = (DateTime)reader["birthdate"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                InsuranceId = reader["insurance_id"] is DBNull ? 0 : (int)reader["insurance_id"],
                AdressId = (int)reader["adress_id"]
            };

        }

        internal static AdressDal ToAdressDal(this DbDataReader reader)
        {
            return new AdressDal()
            {
                Id = (int)reader["Id"],
                Number= (int)reader["number"],
                Street = (string)reader["street"],
                PostCode= (string)reader["postCode"],
                City= (string)reader["city"],
                Country= (string)reader["country"]
            };

        }
    }
}

