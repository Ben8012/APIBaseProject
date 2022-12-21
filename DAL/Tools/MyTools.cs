using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class MyTools
    {
        private readonly Connection _connection;
        

        public MyTools(Connection connection)
        {
            _connection = connection;
            
        }
        public bool IsForeignKeyValid(string table, int id)
        {
            Command cmd = new Command($"SELECT Id FROM [{table}] WHERE Id =@Id", false);
            cmd.AddParameter("Id", id);

            try
            {
                int? result = (int?)_connection.ExecuteScalar(cmd);
                if (!result.HasValue) return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
