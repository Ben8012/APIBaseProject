using API.Models.DTO;
using API.Models.Forms.Club;
using API.Models.Forms.Divelog;
using BLL.Models.DTO;
using BLL.Models.Forms.Club;
using BLL.Models.Forms.Divelog;

namespace API.Mappers
{
    public static class DivelogMapperApi
    {
        internal static Divelog ToDivelog(this DivelogBll divelogBll)
        {
            return new Divelog()
            {
                Id= divelogBll.Id,
                Description= divelogBll.Description,
                DiveType = divelogBll.DiveType,
                Duration= divelogBll.Duration,
                DiveDate = divelogBll.DiveDate,
                MaxDeep = divelogBll.MaxDeep,
                AirTemperature= divelogBll.AirTemperature,
                WaterTemperature= divelogBll.WaterTemperature,
                CreatedAt= divelogBll.CreatedAt,
                UpdatedAt= divelogBll.UpdatedAt,
                IsActive= divelogBll.IsActive,
                User= divelogBll.User is null ? null : divelogBll.User.ToUser(),
                Event= divelogBll.Event is null ? null : divelogBll.Event.ToEvent(),      

            };
        }

        internal static AddDivelogFormBll ToAddDivelogFromBll(this AddDivelogForm addDivelogFrom)
        {
            return new AddDivelogFormBll()
            {
               Description= addDivelogFrom.Description,
               DiveType = addDivelogFrom.DiveType,
               Duration= addDivelogFrom.Duration,
               DiveDate = addDivelogFrom.DiveDate,
               AirTemperature= addDivelogFrom.AirTemperature,
               WaterTemperature= addDivelogFrom.WaterTemperature,
               UserId= addDivelogFrom.UserId,
               EventId= addDivelogFrom.EventId,
               MaxDeep= addDivelogFrom.MaxDeep,
            };
        }

        internal static UpdateDivelogFormBll ToUpdateDivelogFormBll(this UpdateDivelogForm updateDivelogForm)
        {
            return new UpdateDivelogFormBll()
            {
                Id = updateDivelogForm.Id,
                Description = updateDivelogForm.Description,
                DiveType = updateDivelogForm.DiveType,
                Duration = updateDivelogForm.Duration,
                DiveDate = updateDivelogForm.DiveDate,
                AirTemperature = updateDivelogForm.AirTemperature,
                WaterTemperature = updateDivelogForm.WaterTemperature,
                UserId = updateDivelogForm.UserId,
                EventId = updateDivelogForm.EventId,
                MaxDeep = updateDivelogForm.MaxDeep,

            };
        }
    }
}
