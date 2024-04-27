using BLL.Models.DTO;
using BLL.Models.Forms.Divelog;
using BLL.Models.Forms.Diveplace;
using DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDiveplaceBll
    {
        IEnumerable<DiveplaceBll> GetAll();
        IEnumerable<DiveplaceBll> GetAllSiteAndVote(int userId);
        

        DiveplaceBll? GetById(int id);

        DiveplaceBll? Insert(DiveplaceFormBll form);

        DiveplaceBll? Update(DiveplaceFormBll form);

        int? Delete(int id);
        int? Enable(int id);

        int? Disable(int id);

        List<DiveplaceBll> Vote(int userId, int diveplaceId, int vote);

        int GetVoteByUserIdAndDiveplaceId(int userId, int diveplaceId);

        int GetVoteAverageByDiveplaceId(int diveplaceId);
    }
}
