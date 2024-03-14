using API.Models.DTO;
using API.Models.Forms.Divelog;
using API.Models.Forms.Diveplace;
using BLL.Models.DTO;
using BLL.Models.Forms.Divelog;
using BLL.Models.Forms.Diveplace;
using DAL.Models.DTO;

namespace API.Mappers
{
    public static class DiveplaceMapperAPI
    {
        internal static Diveplace ToDiveplace(this DiveplaceBll diveplaceBll)
        {
            return new Diveplace()
            {
               Id= diveplaceBll.Id,
               Name= diveplaceBll.Name,
               Picture= diveplaceBll.Picture, 
               Map = diveplaceBll.Map,
               Description= diveplaceBll.Description,
               CreatedAt= diveplaceBll.CreatedAt,
               UpdatedAt= diveplaceBll.UpdatedAt,
               IsActive= diveplaceBll.IsActive,
               Adress = diveplaceBll.Adress is null ? null : diveplaceBll.Adress.ToAdress(),
                Gps = diveplaceBll.Gps,
                MaxDepp = diveplaceBll.MaxDepp,
                Price = diveplaceBll.Price,
                Compressor = diveplaceBll.Compressor,
                Restoration = diveplaceBll.Restoration,
            };
        }

        internal static AddDiveplaceFormBll ToAddDiveplaceFromBll(this AddDiveplaceForm addDiveplaceFrom)
        {
            return new AddDiveplaceFormBll()
            {
                Name= addDiveplaceFrom.Name,
                Picture= addDiveplaceFrom.Picture,
                Map = addDiveplaceFrom.Map,
                Description= addDiveplaceFrom.Description,
                AdressId = addDiveplaceFrom.AdressId
            };
        }

        internal static UpdateDiveplaceFormBll ToUpdateDiveplaceFormBll(this UpdateDiveplaceForm updateDiveplaceForm)
        {
            return new UpdateDiveplaceFormBll()
            {
                Id= updateDiveplaceForm.Id,
                Name = updateDiveplaceForm.Name,
                Picture = updateDiveplaceForm.Picture,
                Map = updateDiveplaceForm.Map,
                Description = updateDiveplaceForm.Description,
                AdressId = updateDiveplaceForm.AdressId
            };
        }
    }
}
