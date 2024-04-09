using DAL.Models.DTO;
using DAL.Models.Forms.Adress;
using DAL.Models.Forms.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdressDal
    {
        IEnumerable<AdressDal> GetAll();
        AdressDal GetById(int? id);
        AdressDal Insert(AdressFormDal form);
        AdressDal Update(AdressFormDal form);
    }
}
