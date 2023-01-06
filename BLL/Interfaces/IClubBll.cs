using BLL.Models.DTO;
using BLL.Models.Forms;
using BLL.Models.Forms.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClubBll
    {
        IEnumerable<ClubBll> GetAll();

        ClubBll? GetById(int id);

        ClubBll? Insert(AddClubFormBll form);

        ClubBll? Update(UpdateClubFormBll form);

        int? Delete(int id);

        int? Enable(int id);

        int? Disable(int id);

        int? Participate(int userId, int clubId);

        int? UnParticipate(int userId,int clubId);
    }
}
