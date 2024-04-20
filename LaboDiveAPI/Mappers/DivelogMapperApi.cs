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
                Duration= divelogBll.Duration,
                MaxDeep = divelogBll.MaxDeep,
                AirTemperature= divelogBll.AirTemperature,
                WaterTemperature= divelogBll.WaterTemperature,
                CreatedAt= divelogBll.CreatedAt,
                UpdatedAt= divelogBll.UpdatedAt,
                IsActive= divelogBll.IsActive,
                UserId= divelogBll.UserId,
                EventId = divelogBll.EventId    

            };
        }

        internal static AddDivelogFormBll ToAddDivelogFromBll(this AddDivelogForm addDivelogFrom)
        {
            return new AddDivelogFormBll()
            {
               Description= addDivelogFrom.Description,
               Duration= addDivelogFrom.Duration,
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
                Duration = updateDivelogForm.Duration,
                AirTemperature = updateDivelogForm.AirTemperature,
                WaterTemperature = updateDivelogForm.WaterTemperature,
                UserId = updateDivelogForm.UserId,
                EventId = updateDivelogForm.EventId,
                MaxDeep = updateDivelogForm.MaxDeep,

            };
        }
    }
}
