using DAL.Models.DTO;
using DAL.Models.Forms.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEventDal
    {
        IEnumerable<EventDal> GetAll();
        EventDal? GetById(int id);
        EventDal? Insert(AddEventFormDal form);
        EventDal? Update(UpdateEventFormDal form);

        int? Delete(int id);
        int? Enable(int id);
        int? Disable(int id);

        int? Participate(int userId, int eventId);

        int? UnParticipate(int userId, int eventId);

        int? Invite(int inviterId, int invitedId, int eventId);
        int? UnInvite(int inviterId, int invitedId, int eventId);

        IEnumerable<EventDal> GetEventByUserId(int id);
        IEnumerable<UserDal> GetAllParticipeByEventId(int id);

    }
}
