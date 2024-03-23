using API.Models.DTO;
using API.Models.Forms.Adress;
using BLL.Models.DTO;
using BLL.Models.Forms.Adress;

namespace API.Mappers
{
    public static class AdressMapperAPI
    {
        internal static Adress ToAdress(this AdressBll adressBll)
        {
            return new Adress()
            {
                Id = adressBll.Id,
                Number = adressBll.Number,
                Street = adressBll.Street,
                PostCode = adressBll.PostCode,
                City = adressBll.City,
                Country = adressBll.Country
            };

        }

        internal static AdressFormBll ToAdressBll(this AdressForm adress)
        {
            return new AdressFormBll()
            {
                Id = adress.Id,
                Number = adress.Number,
                Street = adress.Street,
                PostCode = adress.PostCode,
                City = adress.City,
                Country = adress.Country
            };

        }
    }
}
