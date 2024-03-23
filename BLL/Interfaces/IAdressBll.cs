using BLL.Models.DTO;
using BLL.Models.Forms.Adress;
using DAL.Models.DTO;
using DAL.Models.Forms.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdressBll
    {
        IEnumerable<AdressBll> GetAll();
        AdressBll GetById(int id);
        AdressBll Insert(AdressFormBll form);
        AdressBll Update(AdressFormBll form);
    }
}
