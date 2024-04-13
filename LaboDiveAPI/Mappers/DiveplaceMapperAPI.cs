using API.Models.DTO;
using API.Models.Forms.Divelog;
using API.Models.Forms.Diveplace;
using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms.Adress;
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
               GuidImage= diveplaceBll.GuidImage, 
               GuidMap = diveplaceBll.GuidMap,
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
               AvgVote= diveplaceBll.AvgVote,
               Url = diveplaceBll.Url,
               UserVote= diveplaceBll.UserVote,
               CreatorId= diveplaceBll.CreatorId,
            };
        }

        internal static DiveplaceFormBll ToDiveplaceFormBll(this DiveplaceForm diveplaceFrom)
        {
            return new DiveplaceFormBll()
            {
                Id= diveplaceFrom.Id,
                Name= diveplaceFrom.Name,
                Description= diveplaceFrom.Description,
                Compressor = diveplaceFrom.Compressor,
                Restoration= diveplaceFrom.Restoration,
                Gps= diveplaceFrom.Gps,
                Url= diveplaceFrom.Url,
                MaxDeep= diveplaceFrom.MaxDeep,
                Price= diveplaceFrom.Price,
                Adress = diveplaceFrom.Adress is null ? null : diveplaceFrom.Adress.ToAdressBll(),
                CreatorId= diveplaceFrom.CreatorId,
            };
        }  
    }
}