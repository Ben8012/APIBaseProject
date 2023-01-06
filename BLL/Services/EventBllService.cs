using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Diveplace;
using BLL.Models.Forms.Event;
using DAL.Interfaces;
using DAL.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EventBllService : IEventBll
    {

        private readonly ILogger _logger;
        private readonly IEventDal _eventDal;

        public EventBllService(ILogger<EventBllService> logger, IEventDal eventDal)
        {
            _eventDal = eventDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _eventDal.Delete(id);
        }

        public IEnumerable<EventBll> GetAll()
        {
            return _eventDal.GetAll().Select(u => u.ToEventBll());
        }

        public EventBll? GetById(int id)
        {
            return _eventDal.GetById(id)?.ToEventBll();
        }

        public EventBll? Insert(AddEventFormBll form)
        {
            return _eventDal.Insert(form.ToAddEventFromDal())?.ToEventBll();
        }

        public EventBll? Update(UpdateEventFormBll form)
        {
            return _eventDal.Update(form.ToUpdateEventFormDal())?.ToEventBll();
        }

        public int? Disable(int id)
        {
            return _eventDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _eventDal.Enable(id); ;
        }

        public int? Participate(int userId, int eventId)
        {
            return _eventDal.Participate(userId, eventId);
        }

        public int? UnParticipate(int userId, int eventId)
        {
            return _eventDal.UnParticipate(userId, eventId);
        }

        public int? Invite(int inviterId, int invitedId, int eventId)
        {
            return _eventDal.Invite(inviterId, invitedId, eventId);
        }

        public int? UnInvite(int inviterId, int invitedId, int eventId)
        {
            return _eventDal.UnInvite(inviterId, invitedId, eventId);
        }
    }
}
