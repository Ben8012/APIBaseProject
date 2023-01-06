using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Event;
using BLL.Models.Forms.Insurance;
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
    public class InsuranceBllService : IInsuranceBll
    {

        private readonly ILogger _logger;
        private readonly IInsuranceDal _insuranceDal;

        public InsuranceBllService(ILogger<InsuranceBllService> logger, IInsuranceDal insuranceDal)
        {
            _insuranceDal = insuranceDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _insuranceDal.Delete(id);
        }

        public IEnumerable<InsuranceBll> GetAll()
        {
            return _insuranceDal.GetAll().Select(u => u.ToInsuranceBll());
        }

        public InsuranceBll? GetById(int id)
        {
            return _insuranceDal.GetById(id)?.ToInsuranceBll();
        }

        public InsuranceBll? Insert(AddInsuranceFormBll form)
        {
            return _insuranceDal.Insert(form.ToAddInsuranceFromDal())?.ToInsuranceBll();
        }

        public InsuranceBll? Update(UpdateInsuranceFormBll form)
        {
            return _insuranceDal.Update(form.ToUpdateInsuranceFormDal())?.ToInsuranceBll();
        }

        public int? Disable(int id)
        {
            return _insuranceDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _insuranceDal.Enable(id); ;
        }
    }
}
