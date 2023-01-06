using DAL.Models.DTO;
using DAL.Models.Forms.Divelog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDivelogDal
    {
        IEnumerable<DivelogDal> GetAll();
        DivelogDal? GetById(int id);
        DivelogDal? Insert(AddDivelogFormDal form);
        DivelogDal? Update(UpdateDivelogFormDal form);

        int? Delete(int id);

        int? Enable(int id);
        int? Disable(int id);
    }
}
