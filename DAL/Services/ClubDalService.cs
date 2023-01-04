using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Club;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class ClubDalService : IClubDal
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public ClubDalService(ILogger<UserDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClubDal> GetAll()
        {
            Command command = new Command("SELECT Id, name, createdAt, updatedAt, isActive,  adress_id, creator_id FROM [Club];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToClubDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public ClubDal? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ClubDal? Insert(AddClubFormDal form)
        {
            throw new NotImplementedException();
        }

        public ClubDal? Update(UpdateClubFormDal form)
        {
            throw new NotImplementedException();
        }
    }
}
