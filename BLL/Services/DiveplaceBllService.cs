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

        public DiveplaceBllService(ILogger<DiveplaceBllService> logger, IDiveplaceDal diveplaceDal)
        {
            _diveplaceDal = diveplaceDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _diveplaceDal.Delete(id);
        }

        public IEnumerable<DiveplaceBll> GetAll()
        {
            return _diveplaceDal.GetAll().Select(u => u.ToDiveplaceBll());
        }

        public DiveplaceBll? GetById(int id)
        {
            return _diveplaceDal.GetById(id)?.ToDiveplaceBll();
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

        public int? Vote(int userId, int diveplaceId, int vote)
        {
            return _diveplaceDal.Vote( userId, diveplaceId, vote);
        }
    }
}
