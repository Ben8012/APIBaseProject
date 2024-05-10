using BLL.Models.DTO;
using BLL.Models.Forms.Event;
using DAL.Models.DTO;
using DAL.Models.Forms.Event;
using Microsoft.Extensions.Logging;

namespace BLL.Mappers
{
    public static class EventMapperBll
    {
        public static EventBll ToEventBll(this EventDal eventDal)
        {
            return new EventBll()
            {

                Id = eventDal.Id,
                Name = eventDal.Name,
                StartDate = eventDal.StartDate,
                EndDate = eventDal.EndDate,
                CreatedAt = eventDal.CreatedAt,
                UpdatedAt = eventDal.UpdatedAt,
                IsActive = eventDal.IsActive,
                DiveplaceId = eventDal.DiveplaceId,
                CreatorId = eventDal.CreatorId,
                TrainingId = eventDal.TrainingId,
                ClubId = eventDal.ClubId
            };
        }

        internal static AddEventFormDal ToAddEventFromDal(this AddEventFormBll addEventFromBll)
        {
            return new AddEventFormDal()
            {
                Name = addEventFromBll.Name,
                StartDate = addEventFromBll.StartDate,
                EndDate = addEventFromBll.EndDate,
                DiveplaceId = addEventFromBll.DiveplaceId,
                CreatorId = addEventFromBll.CreatorId,
                TrainingId = addEventFromBll.TrainingId,
                ClubId = addEventFromBll.ClubId
            };
        }

        internal static UpdateEventFormDal ToUpdateEventFormDal(this UpdateEventFormBll updateEventFormBll)
        {
            return new UpdateEventFormDal()
            {
                Id = updateEventFormBll.Id,
                Name = updateEventFormBll.Name,
                StartDate = updateEventFormBll.StartDate,
                EndDate = updateEventFormBll.EndDate,
                DiveplaceId = updateEventFormBll.DiveplaceId,
                CreatorId = updateEventFormBll.CreatorId,
                TrainingId = updateEventFormBll.TrainingId,
                ClubId = updateEventFormBll.ClubId
            };
        }
    }
}
