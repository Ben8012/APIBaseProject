using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Club;
using DAL.Interfaces;
using DAL.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClubBllService : IClubBll
    {
        private readonly ILogger _logger;
        private readonly IClubDal _clubDal;

        public ClubBllService(ILogger<ClubBllService> logger, IClubDal clubDal)
        {
            _clubDal = clubDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _clubDal.Delete(id);
        }

        public IEnumerable<ClubBll> GetAll()
        {
            return _clubDal.GetAll().Select(u => u.ToClubBll());
        }

        public ClubBll? GetById(int id)
        {
            return _clubDal.GetById(id)?.ToClubBll();
        }

        public ClubBll? Insert(AddClubFormBll form)
        {
            return _clubDal.Insert(form.ToAddClubFromDal())?.ToClubBll(); 
        }

        public ClubBll? Update(UpdateClubFormBll form)
        {
            return _clubDal.Update(form.ToUpdateClubFormDal())?.ToClubBll();
        }

        public int? Disable(int id)
        {
            return _clubDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _clubDal.Enable(id); 
        }

        public int? Participate(int userId, int clubId)
        {
            return _clubDal.Participate(userId, clubId);
        }

        public int? UnParticipate(int userId, int clubId)
        {
            return _clubDal.UnParticipate(userId, clubId);
        }
    }
}
