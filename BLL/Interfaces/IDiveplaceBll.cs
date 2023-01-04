using BLL.Models.DTO;
using BLL.Models.Forms.Divelog;
using BLL.Models.Forms.Diveplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDiveplaceBll
    {
        IEnumerable<DiveplaceBll> GetAll();

        DiveplaceBll? GetById(int id);

        DiveplaceBll? Insert(AddDiveplaceFormBll form);

        DiveplaceBll? Update(UpdateDiveplaceFormBll form);

        int? Delete(int id);
    }
}
