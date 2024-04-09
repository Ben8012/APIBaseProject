
using BLL.Models.DTO;
using BLL.Models.Forms;
using BLL.Models.Forms.Club;
using DAL.Models.DTO;
using DAL.Models.Forms;
using DAL.Models.Forms.Club;

namespace BLL.Mappers
{
    public static class ClubMapperBll
    {

        internal static ClubBll ToClubBll(this ClubDal clubDal)
        {
            return new ClubBll()
            {
                Id = clubDal.Id,
                Name = clubDal.Name,
                UpdatedAt = clubDal.UpdatedAt,
                IsActive = clubDal.IsActive,
                AdressId = clubDal.AdressId,
                CreatorId = clubDal.CreatorId

            };
        }

        internal static ClubFormDal ToClubFormDal(this ClubFormBll clubFormBll)
        {
            return new ClubFormDal()
            {
                Id = clubFormBll.Id,
                Name = clubFormBll.Name,
                CreatorId = clubFormBll.CreatorId,
                AdressId = clubFormBll.AdressId,
            };
        }

 
    }
}
