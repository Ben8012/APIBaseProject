using DAL.Models.DTO;
using DAL.Models.Forms.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IInsuranceDal
    {
        IEnumerable<InsuranceDal> GetAll();
        InsuranceDal? GetById(int id);
        InsuranceDal? Insert(AddInsuranceFormDal form);
        InsuranceDal? Update(UpdateInsuranceFormDal form);

        int? Delete(int id);

        int? Enable(int id);
        int? Disable(int id);
    }
}
