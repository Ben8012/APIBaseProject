using API.Models.DTO;
using API.Models.Forms.Event;
using API.Models.Forms.Insurance;
using BLL.Models.DTO;
using BLL.Models.Forms.Event;
using BLL.Models.Forms.Insurance;

namespace API.Mappers
{
    public static class InsuranceMapperAPI
    {
        internal static Insurance ToInsurance(this InsuranceBll insuranceBll)
        {
            return new Insurance()
            {
                Id= insuranceBll.Id,
                Name= insuranceBll.Name,
                Picture = insuranceBll.Picture,
                CreatedAt= insuranceBll.CreatedAt,
                UpdatedAt= insuranceBll.UpdatedAt,
                IsActive= insuranceBll.IsActive,
                Adress = insuranceBll.Adress is null ? null : insuranceBll.Adress.ToAdress(),
            };
         
        }

        internal static AddInsuranceFormBll ToAddInsuranceFromBll(this AddInsuranceForm addInsuranceFrom)
        {
            return new AddInsuranceFormBll()
            {
                Name = addInsuranceFrom.Name,
                Picture = addInsuranceFrom.Picture,
                AdressId = addInsuranceFrom.AdressId,
            };
        }

        internal static UpdateInsuranceFormBll ToUpdateInsuranceFormBll(this UpdateInsuranceForm updateInsuranceForm)
        {
            return new UpdateInsuranceFormBll()
            {
                Id = updateInsuranceForm.Id,
                Name = updateInsuranceForm.Name,
                Picture = updateInsuranceForm.Picture,
                AdressId = updateInsuranceForm.AdressId,
            };
        }
    }
}
