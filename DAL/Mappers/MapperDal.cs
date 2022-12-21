using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class MapperDal
    {
        internal static UserDal ToUserDal(this DbDataReader reader)
        {
            return new UserDal()
            {
                Id = (int)reader["Id"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Birthdate = (DateTime)reader["Birthdate"],
                Email = (string)reader["Email"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
            };
        }

      
    }
}

