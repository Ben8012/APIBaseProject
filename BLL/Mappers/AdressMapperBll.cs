using BLL.Models.DTO;
using BLL.Models.Forms.Adress;
using DAL.Models.DTO;
using DAL.Models.Forms.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class AdressMapperBll
    {
        public static AdressBll ToAdressBll(this AdressDal adressDal)
        {
            return new AdressBll()
            {
                Id = adressDal.Id,
                Number = adressDal.Number,
                Street = adressDal.Street,
                PostCode = adressDal.PostCode,
                City = adressDal.City,
                Country = adressDal.Country
            };
        }


        public static AdressFormDal ToAdressFormDal(this AdressFormBll adressBll)
        {
            return new AdressFormDal()
            {
                Id = adressBll.Id,
                Number = adressBll.Number,
                Street = adressBll.Street,
                PostCode = adressBll.PostCode,
                City = adressBll.City,
                Country = adressBll.Country
            };
        }


    }
}
