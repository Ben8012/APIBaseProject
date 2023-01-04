using API.Models.DTO;
using API.Models.DTO.UserAPI;
using API.Models.Forms.Club;
using API.Models.Forms.UserAPI;
using BLL.Models.DTO;
using BLL.Models.DTO.User;
using BLL.Models.Forms;
using BLL.Models.Forms.Club;

namespace API.Mappers
{
    public static class ClubMapperAPI
    {
        internal static Club ToClub(this ClubBll clubBll)
        {
            return new Club()
            {
                Id = clubBll.Id,
                Name = clubBll.Name,
                UpdatedAt = clubBll.UpdatedAt,
                IsActive = clubBll.IsActive,
                AdressId = clubBll.AdressId,
                CreatorId = clubBll.CreatorId

            };
        }

        internal static AddClubFormBll ToAddUserFromBll(this AddClubForm addClubFrom)
        {
            return new AddClubFormBll()
            {
                Name= addClubFrom.Name,
                CreatorId= addClubFrom.CreatorId,
                AdressId= addClubFrom.AdressId,
            };
        }

        internal static UpdateClubFormBll ToUpdateUserFormBll(this UpdateClubForm updateClubForm)
        {
            return new UpdateClubFormBll()
            {
                Id = updateClubForm.Id,
                Name = updateClubForm.Name,
                CreatorId = updateClubForm.CreatorId,
                AdressId = updateClubForm.AdressId,

            };
        }
    }
}
