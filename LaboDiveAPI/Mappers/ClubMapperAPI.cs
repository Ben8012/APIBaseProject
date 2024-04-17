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
                Demands = clubBll.Demands is null ? null : clubBll.Demands.Select(p => p.ToUser()).ToList(),

            };
        }

        internal static ClubFormBll ToClubFormBll(this ClubForm clubForm)
        {
            return new ClubFormBll()
            {
                Id = clubForm.Id,
                Name = clubForm.Name,
                CreatorId= clubForm.CreatorId,
                Adress = clubForm.Adress is null ? null : clubForm.Adress.ToAdressBll(),
            };
        }

    }
}
