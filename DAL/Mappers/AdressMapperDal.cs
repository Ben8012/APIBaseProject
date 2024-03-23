using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Mappers
{
    public static class AdressMapperDal
    {
        internal static AdressDal ToAdressDal(this DbDataReader reader)
        {
            return new AdressDal()
            {
                Id = (int)reader["Id"],
                Street = (string)reader["street"],
                Number = (int)reader["number"],
                City = (string)reader["city"],
                PostCode = (string)reader["postCode"],
                Country = (string)reader["country"],
               
            };
        }
    }
}
