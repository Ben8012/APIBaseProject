using BLL.Models.DTO;
using BLL.Models.Forms.Event;
using BLL.Models.Forms.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IInsuranceBll
    {
        IEnumerable<InsuranceBll> GetAll();

        InsuranceBll? GetById(int id);

        InsuranceBll? Insert(AddInsuranceFormBll form);

        InsuranceBll? Update(UpdateInsuranceFormBll form);

        int? Delete(int id);
    }
}
