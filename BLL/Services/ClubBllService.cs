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
        private readonly ITrainingBll _trainingBll;

        public ClubBllService(ILogger<ClubBllService> logger, IClubDal clubDal, IUserBll userBll, IAdressBll adressBll, ITrainingBll trainingBll)
        {
            _clubDal = clubDal;
            _logger = logger;
            _userBll = userBll;
            _adressBll = adressBll;
            _trainingBll = trainingBll;
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
                foreach (var participe in club.Participes)
                {
                    participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
                }
                club.Demands = GetAllDemandsByClubId(club.Id).ToList();
                foreach (var demand in club.Demands)
                {
                    demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
                }
            }
            return clubs;
        }

        public ClubBll? GetById(int id)
        {
            ClubBll club = _clubDal.GetById(id)?.ToClubBll();
            club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
            club.Creator = club.CreatorId == 0 ? null : _userBll.GetById(club.CreatorId);
            club.Participes = GetAllParticipeByClubId(club.Id).ToList();
            foreach (var participe in club.Participes)
            {
                participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
            }
            club.Demands = GetAllDemandsByClubId(club.Id).ToList();
            foreach (var demand in club.Demands)
            {
                demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
            }
            return club;
        }

        public ClubBll? Insert(ClubFormBll form)
        {
            if (form.Adress is not null)
            {
                AdressBll adress = _adressBll.Insert(form.Adress);
                form.AdressId = adress.Id;
            }
            else
            {
                form.AdressId = null;
            }
            ClubBll club = _clubDal.Insert(form.ToClubFormDal()).ToClubBll();
            club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
            club.Creator = club.CreatorId == 0 ? null : _userBll.GetById(club.CreatorId);
            club.Participes = GetAllParticipeByClubId(club.Id).ToList();
            foreach (var participe in club.Participes)
            {
                participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
            }
            club.Demands = GetAllDemandsByClubId(club.Id).ToList();
            foreach (var demand in club.Demands)
            {
                demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
            }
            return club;
        }

        public ClubBll? Update(ClubFormBll form)
        {
            if (form.Adress is not null && form.Adress.Id is not null)
            {
                AdressBll adress = _adressBll.Update(form.Adress);
                form.AdressId = adress.Id;
            }
            else if(form.Adress is not null && form.Adress.Id is null)
            {
                AdressBll adress = _adressBll.Insert(form.Adress);
                form.AdressId = adress.Id;
            }
            else
            {
                form.AdressId = null;
            }
            ClubBll club = _clubDal.Update(form.ToClubFormDal()).ToClubBll();
            club.Adress = club.AdressId == 0 ? null : _adressBll.GetById(club.AdressId);
            club.Creator = club.CreatorId == 0 ? null : _userBll.GetById(club.CreatorId);
            club.Participes = GetAllParticipeByClubId(club.Id).ToList();
            foreach (var participe in club.Participes)
            {
                participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
            }
            club.Demands = GetAllDemandsByClubId(club.Id).ToList();
            foreach (var demand in club.Demands)
            {
                demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
            }
            return club;
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
                foreach (var participe in club.Participes)
                {
                    participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
                }
                club.Demands = GetAllDemandsByClubId(club.Id).ToList();
                foreach (var demand in club.Demands)
                {
                    demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
                }
            }
            return clubs;
        }

        public IEnumerable<UserBll> GetAllParticipeByClubId(int id)
        {
            return _clubDal.GetAllParticipeByClubId(id).Select(c => c.ToUserBll()).ToList();
        }
        public IEnumerable<UserBll> GetAllDemandsByClubId(int id)
        {
            return _clubDal.GetAllDemandsByClubId(id).Select(c => c.ToUserBll()).ToList(); ;
        }

        public int? ValidationParticipate(int userId, int clubId)
        {
            return _clubDal.ValidationParticipate(userId, clubId);
        }

        public int? UnValidationParticipate(int userId, int clubId)
        {
            return _clubDal.UnValidationParticipate(userId, clubId);
        }

    }
}
