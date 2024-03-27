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
        private readonly IUserBll _userBll;
        private readonly IAdressBll _adressBll;

        public ClubBllService(ILogger<ClubBllService> logger, IClubDal clubDal, IUserBll userBll, IAdressBll adressBll)
        {
            _clubDal = clubDal;
            _logger = logger;
            _userBll = userBll;
            _adressBll = adressBll;
        }

        public int? Delete(int id)
        {
            return _clubDal.Delete(id);
        }

        public IEnumerable<ClubBll> GetAll()
        {
            List<ClubBll> clubs = _clubDal.GetAll().Select(u => u.ToClubBll()).ToList();
            foreach (var club in clubs)
            {
                club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
                club.Creator = club.CreatorId == 0 ? null : _userBll.GetById(club.CreatorId);
                club.Participes = GetAllParticipeByClubId(club.Id).ToList();
            }
            return clubs;
        }

        public ClubBll? GetById(int id)
        {
            ClubBll club = _clubDal.GetById(id)?.ToClubBll();
            club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
            club.Creator = club.CreatorId == 0 ? null : _userBll.GetById(club.CreatorId);
            club.Participes = GetAllParticipeByClubId(club.Id).ToList();
            return club;
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

        public IEnumerable<ClubBll> GetClubsByUserId(int id)
        {
            List<ClubBll> clubs = _clubDal.GetClubsByUserId(id).Select(c => c.ToClubBll()).ToList();
            foreach (var club in clubs)
            {
                club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
                club.Creator = club.CreatorId == 0 ? null : _userBll.GetById(club.CreatorId);
                club.Participes = GetAllParticipeByClubId(club.Id).ToList();
            }
            return clubs;
        }

        public IEnumerable<UserBll> GetAllParticipeByClubId(int id)
        {
            return _clubDal.GetAllParticipeByClubId(id).Select(c => c.ToUserBll()).ToList();
        }
    }
}
