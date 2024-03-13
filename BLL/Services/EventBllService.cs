﻿using BLL.Interfaces;
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
        private readonly IDiveplaceBll _diveplaceBll;
        private readonly IClubBll _clubBll;
        private readonly IUserBll _userBll;
        private readonly ITrainingBll _trainingBll;

        public EventBllService(ILogger<EventBllService> logger, IEventDal eventDal, IDiveplaceBll diveplaceBll, IClubBll clubBll, IUserBll userBll, ITrainingBll trainingBll)
        {
            _eventDal = eventDal;
            _logger = logger;
            _diveplaceBll = diveplaceBll;   
            _clubBll= clubBll;
            _userBll = userBll;
            _trainingBll = trainingBll;
        }

        public int? Delete(int id)
        {
            return _eventDal.Delete(id);
        }

        public IEnumerable<EventBll> GetAll()
        {
            List<EventBll> events = _eventDal.GetAll().Select(u => u.ToEventBll()).ToList();
            foreach (var e in events)
            {
                e.Diveplace = e.DiveplaceId == 0 ? null : _diveplaceBll.GetById(e.DiveplaceId);
                e.Club = e.ClubId == 0 ? null : _clubBll.GetById(e.ClubId);
                e.Creator = e.CreatorId == 0 ? null : _userBll.GetById(e.CreatorId);
                e.Training = e.TrainingId == 0 ? null : _trainingBll.GetById(e.TrainingId);
            }
            return events;
        }

        public EventBll? GetById(int id)
        {
            EventBll e = _eventDal.GetById(id)?.ToEventBll();
            e.Diveplace = e.DiveplaceId == 0 ? null : _diveplaceBll.GetById(e.DiveplaceId);
            e.Club = e.ClubId == 0 ? null : _clubBll.GetById(e.ClubId);
            e.Creator = e.CreatorId == 0 ? null : _userBll.GetById(e.CreatorId);
            e.Training = e.TrainingId == 0 ? null : _trainingBll.GetById(e.TrainingId);
            return e;
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
