using BLL.Models.DTO;
using BLL.Models.Forms.Diveplace;
using BLL.Models.Forms.Event;
using DAL.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEventBll
    {
        IEnumerable<EventBll> GetAll();

        EventBll? GetById(int id);

        EventBll? Insert(AddEventFormBll form);

        EventBll? Update(UpdateEventFormBll form);

        int? Delete(int id);
        int? Enable(int id);

        int? Disable(int id);

        int? Participate(int userId, int eventId);

        int? UnParticipate(int userId, int eventId);

        int? Invite(int inviterId, int invitedId, int eventId);
        int? UnInvite(int inviterId, int invitedId, int eventId);

        IEnumerable<UserBll> GetAllParticipeByEventId(int id);
    }
}
