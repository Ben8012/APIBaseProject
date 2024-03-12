using DAL.Models.DTO;
using DAL.Models.Forms.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IClubDal
    {
        IEnumerable<ClubDal> GetAll();
        ClubDal? GetById(int id);
        ClubDal? Insert(AddClubFormDal form);
        ClubDal? Update(UpdateClubFormDal form);

        int? Delete(int id);
        int? Enable(int id);
        int? Disable(int id);

        int? Participate(int userId, int clubId);

        int? UnParticipate(int userId, int clubId);

        IEnumerable<ClubDal>? GetClubsByUserId(int id);
    }
}
