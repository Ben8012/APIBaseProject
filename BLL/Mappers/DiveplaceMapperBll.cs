using BLL.Models.DTO;
using BLL.Models.Forms.Diveplace;
using DAL.Models.DTO;
using DAL.Models.Forms.Diveplace;

namespace BLL.Mappers
{
    public static class DiveplaceMapperBll
    {
        internal static DiveplaceBll ToDiveplace(this DiveplaceDal diveplaceDal)
        {
            return new DiveplaceBll()
            {
                Id = diveplaceDal.Id,
                Name = diveplaceDal.Name,
                Picture = diveplaceDal.Picture,
                Map = diveplaceDal.Map,
                Description = diveplaceDal.Description,
                CreatedAt = diveplaceDal.CreatedAt,
                UpdatedAt = diveplaceDal.UpdatedAt,
                IsActive = diveplaceDal.IsActive,
                AdressId = diveplaceDal.AdressId,

            };
        }

        internal static AddDiveplaceFormDal ToAddDiveplaceFromDal(this AddDiveplaceFormBll addDiveplaceFromBll)
        {
            return new AddDiveplaceFormDal()
            {
                Name = addDiveplaceFromBll.Name,
                Picture = addDiveplaceFromBll.Picture,
                Map = addDiveplaceFromBll.Map,
                Description = addDiveplaceFromBll.Description,
                AdressId = addDiveplaceFromBll.AdressId
            };
        }

        internal static UpdateDiveplaceFormDal ToUpdateDiveplaceFormDal(this UpdateDiveplaceFormBll updateDiveplaceFormBll)
        {
            return new UpdateDiveplaceFormDal()
            {
                Id = updateDiveplaceFormBll.Id,
                Name = updateDiveplaceFormBll.Name,
                Picture = updateDiveplaceFormBll.Picture,
                Map = updateDiveplaceFormBll.Map,
                Description = updateDiveplaceFormBll.Description,
                AdressId = updateDiveplaceFormBll.AdressId
            };
        }
    }
}
