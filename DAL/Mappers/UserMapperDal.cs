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
                Role = (string)reader["role"],
                Birthdate = (DateTime)reader["birthdate"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                IsActive = (bool)reader["isActive"],
                Phone = reader["phone"] is DBNull ? null : (string)reader["phone"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                InsuranceId = reader["insurance_id"] is DBNull ? 0 : (int)reader["insurance_id"],
                AdressId = reader["adress_id"] is DBNull ? 0 : (int)reader["adress_id"]
            };

        }
    }
}

