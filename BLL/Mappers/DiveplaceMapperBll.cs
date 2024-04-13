using BLL.Models.DTO;
using BLL.Models.Forms.Diveplace;
using DAL.Models.DTO;
using DAL.Models.Forms.Diveplace;

namespace BLL.Mappers
{
    public static class DiveplaceMapperBll
    {
        internal static DiveplaceBll ToDiveplaceBll(this DiveplaceDal diveplaceDal)
        {
            return new DiveplaceBll()
            {
                Id = diveplaceDal.Id,
                Name = diveplaceDal.Name,
                GuidImage = diveplaceDal.GuidImage,
                GuidMap = diveplaceDal.GuidMap,
                Description = diveplaceDal.Description,
                CreatedAt = diveplaceDal.CreatedAt,
                UpdatedAt = diveplaceDal.UpdatedAt,
                IsActive = diveplaceDal.IsActive,
                AdressId = diveplaceDal.AdressId,
                Gps = diveplaceDal.Gps,
                MaxDepp = diveplaceDal.MaxDepp,
                Price = diveplaceDal.Price,
                Compressor = diveplaceDal.Compressor,
                Restoration = diveplaceDal.Restoration,
                Url= diveplaceDal.Url,
                CreatorId= diveplaceDal.CreatorId,
            };
        }

       

        internal static DiveplaceFormDal ToDiveplaceFormDal(this DiveplaceFormBll DiveplaceFormBll)
        {
            return new DiveplaceFormDal()
            {
                Id = DiveplaceFormBll.Id,
                Name = DiveplaceFormBll.Name,
                Description = DiveplaceFormBll.Description,
                Compressor = DiveplaceFormBll.Compressor,
                Restoration = DiveplaceFormBll.Restoration,
                Gps = DiveplaceFormBll.Gps,
                Url = DiveplaceFormBll.Url,
                MaxDeep = DiveplaceFormBll.MaxDeep,
                Price = DiveplaceFormBll.Price,
                AdressId = DiveplaceFormBll.AdressId,
                CreatorId = DiveplaceFormBll.CreatorId,
            };
        }
    }
}
