using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Club;
using BLL.Models.Forms.Divelog;
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
    public class DivelogBllService : IDivelogBll
    {

        private readonly ILogger _logger;
        private readonly IDivelogDal _divelogDal;

        public DivelogBllService(ILogger<DivelogBllService> logger, IDivelogDal divelogDal)
        {
            _divelogDal = divelogDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _divelogDal.Delete(id);
        }

        public IEnumerable<DivelogBll> GetAll()
        {
            return _divelogDal.GetAll().Select(u => u.ToDivelogBll());
        }

        public DivelogBll? GetById(int id)
        {
            return _divelogDal.GetById(id)?.ToDivelogBll();
        }

        public DivelogBll? Insert(AddDivelogFormBll form)
        {
            return _divelogDal.Insert(form.ToAddDivelogFromDal())?.ToDivelogBll();
        }

        public DivelogBll? Update(UpdateDivelogFormBll form)
        {
            return _divelogDal.Update(form.ToUpdateDivelogFormDal())?.ToDivelogBll();
        }

        public int? Disable(int id)
        {
            return _divelogDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _divelogDal.Enable(id); ;
        }
    }
}
