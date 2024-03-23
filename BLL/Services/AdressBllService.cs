using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Adress;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdressBllService : IAdressBll
    {
        private readonly IAdressDal _adressDal;
        public AdressBllService(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public IEnumerable<AdressBll> GetAll()
        {
            return _adressDal.GetAll().Select(a => a.ToAdressBll());
        }

        public AdressBll GetById(int id)
        {
            return _adressDal.GetById(id).ToAdressBll();
        }

        public AdressBll? Insert(AdressFormBll form)
        {
            return _adressDal.Insert(form.ToAdressFormDal()).ToAdressBll();
        }

        public AdressBll? Update(AdressFormBll form)
        {
            return _adressDal.Update(form.ToAdressFormDal()).ToAdressBll();
        }
    }
}
