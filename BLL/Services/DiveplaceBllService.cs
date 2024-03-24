using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Divelog;
using BLL.Models.Forms.Diveplace;
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
    public class DiveplaceBllService : IDiveplaceBll
    {

        private readonly ILogger _logger;
        private readonly IDiveplaceDal _diveplaceDal;
        private readonly IUserBll _userBll;
        private readonly IAdressBll _adressBll;

        public DiveplaceBllService(ILogger<DiveplaceBllService> logger, IDiveplaceDal diveplaceDal, IUserBll userBll, IAdressBll adressBll)
        {
            _diveplaceDal = diveplaceDal;
            _logger = logger;
            _userBll = userBll;
            _adressBll = adressBll;
        }

        public int? Delete(int id)
        {
            return _diveplaceDal.Delete(id);
        }

        public IEnumerable<DiveplaceBll> GetAll(int userId)
        {
            List<DiveplaceBll> diveplaces = _diveplaceDal.GetAll().Select(u => u.ToDiveplaceBll()).ToList();
            foreach (var diveplace in diveplaces)
            {
                diveplace.Adress = diveplace.AdressId == 0 ? null : _adressBll.GetById(diveplace.AdressId);
                diveplace.AvgVote = GetVoteAverageByDiveplaceId(diveplace.Id);
                diveplace.UserVote = GetVoteByUserIdAndDiveplaceId(userId, diveplace.Id);

            }
            return diveplaces;
        }

        public DiveplaceBll? GetById(int id)
        {
            DiveplaceBll diveplace = _diveplaceDal.GetById(id)?.ToDiveplaceBll();
            diveplace.Adress = diveplace.AdressId == 0 ? null : _adressBll.GetById(diveplace.AdressId);
            diveplace.AvgVote = GetVoteAverageByDiveplaceId(id);
            diveplace.UserVote = GetVoteByUserIdAndDiveplaceId(id, diveplace.Id);
            return diveplace;
        }

        public DiveplaceBll? Insert(AddDiveplaceFormBll form)
        {
            return _diveplaceDal.Insert(form.ToAddDiveplaceFromDal())?.ToDiveplaceBll();
        }

        public DiveplaceBll? Update(UpdateDiveplaceFormBll form)
        {
            return _diveplaceDal.Update(form.ToUpdateDiveplaceFormDal())?.ToDiveplaceBll();
        }

        public int? Disable(int id)
        {
            return _diveplaceDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _diveplaceDal.Enable(id); 
        }

        public List<DiveplaceBll> Vote(int userId, int diveplaceId, int vote)
        {
            List<DiveplaceBll> diveplaces = _diveplaceDal.Vote(userId, diveplaceId, vote).Select(d => d.ToDiveplaceBll()).ToList();
            foreach (var diveplace in diveplaces)
            {
                diveplace.Adress = diveplace.AdressId == 0 ? null : _adressBll.GetById(diveplace.AdressId);
                diveplace.AvgVote = GetVoteAverageByDiveplaceId(diveplace.Id);
                diveplace.UserVote = GetVoteByUserIdAndDiveplaceId(userId, diveplace.Id);
            }
            return diveplaces;
        }

        public int GetVoteAverageByDiveplaceId(int diveplaceId)
        {
            return _diveplaceDal.GetVoteAverageByDiveplaceId(diveplaceId);
        }

        public int GetVoteByUserIdAndDiveplaceId(int userId, int diveplaceId)
        {
            return _diveplaceDal.GetVoteByUserIdAndDiveplaceId(userId, diveplaceId);
        }
    }
}
