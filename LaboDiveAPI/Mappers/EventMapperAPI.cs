using API.Models.DTO;
using API.Models.Forms.Diveplace;
using API.Models.Forms.Event;
using BLL.Models.DTO;
using BLL.Models.Forms.Diveplace;
using BLL.Models.Forms.Event;

namespace API.Mappers
{
    public static class EventMapperAPI
    {
        internal static Event ToEvent(this EventBll eventBll)
        {
            return new Event()
            {
                
                Id = eventBll.Id,
                Name = eventBll.Name,
                StartDate = eventBll.StartDate,
                EndDate = eventBll.EndDate,
                CreatedAt = eventBll.CreatedAt,
                UpdatedAt = eventBll.UpdatedAt,
                IsActive = eventBll.IsActive,
                Diveplace = eventBll.Diveplace is null ? null : eventBll.Diveplace.ToDiveplace(),
                Creator = eventBll.Creator is null ? null : eventBll.Creator.ToUser(),
                Training = eventBll.Training is null ? null : eventBll.Training.ToTraining(),
                Club = eventBll.Club is null ? null : eventBll.Club.ToClub(),
                Participes = eventBll.Participes is null ? null : eventBll.Participes.Select(u => u.ToUser()).ToList(),
                Demands = eventBll.Demands is null ? null : eventBll.Demands.Select(u => u.ToUser()).ToList(),
                Divelog = eventBll.Divelog is null ? null : eventBll.Divelog.ToDivelog(),
            };
        }

        internal static AddEventFormBll ToAddEventFromBll(this AddEventForm addEventFrom)
        {
            return new AddEventFormBll()
            {
                Name = addEventFrom.Name,
                StartDate = addEventFrom.StartDate,
                EndDate = addEventFrom.EndDate,
                DiveplaceId = addEventFrom.DiveplaceId,
                CreatorId = addEventFrom.CreatorId,
                TrainingId = addEventFrom.TrainingId,
                ClubId = addEventFrom.ClubId
            };
        }

        internal static UpdateEventFormBll ToUpdateEventFormBll(this UpdateEventForm updateEventForm)
        {
            return new UpdateEventFormBll()
            {
                Id = updateEventForm.Id,
                Name = updateEventForm.Name,
                StartDate = updateEventForm.StartDate,
                EndDate = updateEventForm.EndDate,
                DiveplaceId = updateEventForm.DiveplaceId,
                CreatorId = updateEventForm.CreatorId,
                TrainingId = updateEventForm.TrainingId,
                ClubId = updateEventForm.ClubId
            };
        }
    }
}
