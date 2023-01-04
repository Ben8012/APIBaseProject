
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

        internal static AddClubFormDal ToAddUserFromDal(this AddClubFormBll addClubFromBll)
        {
            return new AddClubFormDal()
            {
                Name = addClubFromBll.Name,
                CreatorId = addClubFromBll.CreatorId,
                AdressId = addClubFromBll.AdressId,
            };
        }

        internal static UpdateClubFormDal ToUpdateUserFormDal(this UpdateClubFormBll updateClubFormBll)
        {
            return new UpdateClubFormDal()
            {
                Id = updateClubFormBll.Id,
                Name = updateClubFormBll.Name,
                CreatorId = updateClubFormBll.CreatorId,
                AdressId = updateClubFormBll.AdressId,

            };
        }
    }
}
