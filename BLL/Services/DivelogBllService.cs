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
        private readonly IEventBll _eventBll;
        private readonly IUserBll _userBll;

        public DivelogBllService(ILogger<DivelogBllService> logger, IDivelogDal divelogDal, IEventBll eventBll, IUserBll userBll)
        {
            _divelogDal = divelogDal;
            _logger = logger;
            _eventBll = eventBll;
            _userBll = userBll;
        }

        public int? Delete(int id)
        {
            return _divelogDal.Delete(id);
        }

        public IEnumerable<DivelogBll> GetAll()
        {
            List<DivelogBll> divelogs = _divelogDal.GetAll().Select(u => u.ToDivelogBll()).ToList();
            return divelogs;
        }

        public DivelogBll? GetById(int id)
        {
            DivelogBll divelog = _divelogDal.GetById(id)?.ToDivelogBll();
            return divelog;
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
            return _divelogDal.Enable(id);
        }

        public DivelogBll? GetDivelogByEventId(int id)
        {
            return _divelogDal.GetDivelogByEventId(id).ToDivelogBll();
        }
    }
}
