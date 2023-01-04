using BLL.Models.DTO;
using BLL.Models.Forms.Insurance;
using DAL.Models.DTO;
using DAL.Models.Forms.Insurance;

namespace BLL.Mappers
{
    public static class InsuranceMapperBll
    {
        internal static InsuranceBll ToEventBll(this InsuranceDal insuranceDal)
        {
            return new InsuranceBll()
            {
                Id = insuranceDal.Id,
                Name = insuranceDal.Name,
                Picture = insuranceDal.Picture,
                CreatedAt = insuranceDal.CreatedAt,
                UpdatedAt = insuranceDal.UpdatedAt,
                IsActive = insuranceDal.IsActive,
                AdressId = insuranceDal.AdressId,

            };
        }

        internal static AddInsuranceFormDal ToAddInsuranceFromDal(this AddInsuranceFormBll addInsuranceFromBll)
        {
            return new AddInsuranceFormDal()
            {
                Name = addInsuranceFromBll.Name,
                Picture = addInsuranceFromBll.Picture,
                AdressId = addInsuranceFromBll.AdressId,
            };
        }

        internal static UpdateInsuranceFormDal ToUpdateInsuranceFormDal(this UpdateInsuranceFormBll updateInsuranceFormBll)
        {
            return new UpdateInsuranceFormDal()
            {
                Id = updateInsuranceFormBll.Id,
                Name = updateInsuranceFormBll.Name,
                Picture = updateInsuranceFormBll.Picture,
                AdressId = updateInsuranceFormBll.AdressId,
            };
        }
    }
}
