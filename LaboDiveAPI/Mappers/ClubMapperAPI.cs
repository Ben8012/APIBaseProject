using API.Models.DTO;
using API.Models.Forms.Club;
using BLL.Models.DTO;
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
                Adress = clubBll.Adress is null ? null : clubBll.Adress.ToAdress(),
                Creator = clubBll.Creator is null ? null : clubBll.Creator.ToUser(),
                Participes = clubBll.Participes is null ? null : clubBll.Participes.Select(p => p.ToUser()).ToList(),

            };
        }

        internal static AddClubFormBll ToAddClubFromBll(this AddClubForm addClubFrom)
        {
            return new AddClubFormBll()
            {
                Name= addClubFrom.Name,
                CreatorId= addClubFrom.CreatorId,
                AdressId= addClubFrom.AdressId,
            };
        }

        internal static UpdateClubFormBll ToUpdateClubFormBll(this UpdateClubForm updateClubForm)
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
