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
        private readonly IDiveplaceBll _diveplaceBll;
        private readonly IClubBll _clubBll;
        private readonly IUserBll _userBll;
        private readonly ITrainingBll _trainingBll;
        private readonly IDivelogDal _divelogDal;
        private readonly IUserDal _userDal;

        public EventBllService(ILogger<EventBllService> logger,IUserDal userDal, IEventDal eventDal, IDiveplaceBll diveplaceBll, IClubBll clubBll, IUserBll userBll, ITrainingBll trainingBll, IDivelogDal divelogDal)
        {
            _eventDal = eventDal;
            _logger = logger;
            _diveplaceBll = diveplaceBll;   
            _clubBll= clubBll;
            _userBll = userBll;
            _trainingBll = trainingBll;
            _divelogDal= divelogDal;
            _userDal= userDal;
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
                e.Participes = GetAllParticipeByEventId(e.Id).ToList();
                foreach (var participe in e.Participes)
                {
                    participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
                }
                e.Demands = GetAllDemandsByEventId(e.Id).ToList();
                foreach (var demand in e.Demands)
                {
                    demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
                }
                e.Divelog = _divelogDal.GetDivelogByEventId(e.Id) is null ? null : _divelogDal.GetDivelogByEventId(e.Id).ToDivelogBll();
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
            e.Participes = GetAllParticipeByEventId(e.Id).ToList();
            foreach (var participe in e.Participes)
            {
                participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
            }
            e.Demands = GetAllDemandsByEventId(e.Id).ToList();
            foreach (var demand in e.Demands)
            {
                demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
            }
            e.Divelog = _divelogDal.GetDivelogByEventId(e.Id) is null ? null : _divelogDal.GetDivelogByEventId(e.Id).ToDivelogBll();
            return e;
        }

        public EventBll? Insert(AddEventFormBll form)
        {
            EventBll e = _eventDal.Insert(form.ToAddEventFromDal())?.ToEventBll();
            e.Diveplace = e.DiveplaceId == 0 ? null : _diveplaceBll.GetById(e.DiveplaceId);
            e.Club = e.ClubId == 0 ? null : _clubBll.GetById(e.ClubId);
            e.Creator = e.CreatorId == 0 ? null : _userBll.GetById(e.CreatorId);
            e.Training = e.TrainingId == 0 ? null : _trainingBll.GetById(e.TrainingId);
            e.Participes = GetAllParticipeByEventId(e.Id).ToList();
            foreach (var participe in e.Participes)
            {
                participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
            }
            e.Demands = GetAllDemandsByEventId(e.Id).ToList();
            foreach (var demand in e.Demands)
            {
                demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
            }
            e.Divelog = _divelogDal.GetDivelogByEventId(e.Id) is null ? null : _divelogDal.GetDivelogByEventId(e.Id).ToDivelogBll();
            return e;
        }

        public EventBll? Update(UpdateEventFormBll form)
        {
            EventBll e = _eventDal.Update(form.ToUpdateEventFormDal())?.ToEventBll();
            e.Diveplace = e.DiveplaceId == 0 ? null : _diveplaceBll.GetById(e.DiveplaceId);
            e.Club = e.ClubId == 0 ? null : _clubBll.GetById(e.ClubId);
            e.Creator = e.CreatorId == 0 ? null : _userBll.GetById(e.CreatorId);
            e.Training = e.TrainingId == 0 ? null : _trainingBll.GetById(e.TrainingId);
            e.Participes = GetAllParticipeByEventId(e.Id).ToList();
            foreach (var participe in e.Participes)
            {
                participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
            }
            e.Demands = GetAllDemandsByEventId(e.Id).ToList();
            foreach (var demand in e.Demands)
            {
                demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
            }
            e.Divelog = _divelogDal.GetDivelogByEventId(e.Id) is null ? null : _divelogDal.GetDivelogByEventId(e.Id).ToDivelogBll();
            return e;
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

        public IEnumerable<UserBll> GetAllParticipeByEventId(int id)
        {
            return _eventDal.GetAllParticipeByEventId(id).Select(u => u.ToUserBll());
        }
        public IEnumerable<EventBll> GetEventByUserId(int id)
        {
            List<EventBll> events = _eventDal.GetEventByUserId(id).Select(u => u.ToEventBll()).ToList();
            foreach (var e in events)
            {
                e.Diveplace = e.DiveplaceId == 0 ? null : _diveplaceBll.GetById(e.DiveplaceId);
                e.Club = e.ClubId == 0 ? null : _clubBll.GetById(e.ClubId);
                e.Creator = e.CreatorId == 0 ? null : _userBll.GetById(e.CreatorId);
                e.Training = e.TrainingId == 0 ? null : _trainingBll.GetById(e.TrainingId);
                e.Participes = GetAllParticipeByEventId(e.Id).ToList();
                foreach (var participe in e.Participes)
                {
                    participe.Trainings = _trainingBll.GetTrainingsByUserId(participe.Id).ToList();
                }
                e.Demands = GetAllDemandsByEventId(e.Id).ToList();
                foreach (var demand in e.Demands)
                {
                    demand.Trainings = _trainingBll.GetTrainingsByUserId(demand.Id).ToList();
                }
                e.Divelog = _divelogDal.GetDivelogByEventId(e.Id) is null ? null : _divelogDal.GetDivelogByEventId(e.Id).ToDivelogBll();
            }
            return events;
          
        }

        public IEnumerable<UserBll> GetAllDemandsByEventId(int id)
        {
            return _eventDal.GetAllDemandsByEventId(id).Select(u => u.ToUserBll());
        }

        public int? ValidationParticipate(int userId, int eventId)
        {
            return _eventDal.ValidationParticipate( userId, eventId);
        }

        public int? UnValidationParticipate(int userId, int eventId)
        {
            return _eventDal.UnValidationParticipate(userId, eventId);
        }
    }
}
