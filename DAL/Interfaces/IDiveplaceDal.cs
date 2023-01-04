using DAL.Models.DTO;
using DAL.Models.Forms.Diveplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiveplaceDal
    {
        IEnumerable<DiveplaceDal> GetAll();
        DiveplaceDal? GetById(int id);
        DiveplaceDal? Insert(AddDiveplaceFormDal form);
        DiveplaceDal? Update(UpdateDiveplaceFormDal form);

        int? Delete(int id);
    }
}
