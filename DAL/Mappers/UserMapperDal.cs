using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
                CreatedAt = (DateTime)reader["createdAt"],
                IsActive = (bool)reader["isActive"],
                UpdatedAt = reader["updatedAt"] is DBNull ? null : (DateTime?)reader["updatedAt"],
                AdressId = reader["adress_id"] is DBNull ? 0 : (int)reader["adress_id"],
                GuidImage = reader["guidImage"] is DBNull ? null : (byte[])reader["guidImage"],
                GuidInsurance = reader["guidInsurance"] is DBNull ? null : (byte[])reader["guidInsurance"],
                GuidLevel = reader["guidLevel"] is DBNull ? null : (byte[])reader["guidLevel"],
                GuidCertificat = reader["guidCertificat"] is DBNull ? null : (byte[])reader["guidCertificat"],
                MedicalDateValidation = reader["medicalDateValidation"] is DBNull ? null : (DateTime)reader["medicalDateValidation"],
                InsuranceDateValidation = reader["insuranceDateValidation"] is DBNull ? null : (DateTime)reader["insuranceDateValidation"],
                IsLevelValid = (bool)reader["isLevelValid"],
                
            };

        }
    }
}

