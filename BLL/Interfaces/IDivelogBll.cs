using BLL.Models.DTO;
using BLL.Models.Forms.Club;
using BLL.Models.Forms.Divelog;
using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDivelogBll
    {
        IEnumerable<DivelogBll> GetAll();

        DivelogBll? GetById(int id);
        DivelogBll? GetDivelogByEventId(int id);

        DivelogBll? Insert(AddDivelogFormBll form);

        DivelogBll? Update(UpdateDivelogFormBll form);

        int? Delete(int id);
        int? Enable(int id);

        int? Disable(int id);
    }
}
