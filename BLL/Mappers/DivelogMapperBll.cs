using BLL.Models.DTO;
using BLL.Models.Forms.Divelog;
using DAL.Models.DTO;
using DAL.Models.Forms.Divelog;

namespace BLL.Mappers
{
    public static class DivelogMapperBll
    {
       
            internal static DivelogBll ToDivelogBll(this DivelogDal divelogDal)
            {
                return new DivelogBll()
                {
                    Id = divelogDal.Id,
                    Description = divelogDal.Description,
                    DiveType = divelogDal.DiveType,
                    Duration = divelogDal.Duration,
                    DiveDate = divelogDal.DiveDate,
                    MaxDeep = divelogDal.MaxDeep,
                    AirTemperature = divelogDal.AirTemperature,
                    WaterTemperature = divelogDal.WaterTemperature,
                    CreatedAt = divelogDal.CreatedAt,
                    UpdatedAt = divelogDal.UpdatedAt,
                    IsActive = divelogDal.IsActive,
                    UserId = divelogDal.UserId,
                    EventId = divelogDal.EventId,

                };
            }

            internal static AddDivelogFormDal ToAddDivelogFromDal(this AddDivelogFormBll addDivelogFromBll)
            {
                return new AddDivelogFormDal()
                {
                    Description = addDivelogFromBll.Description,
                    DiveType = addDivelogFromBll.DiveType,
                    Duration = addDivelogFromBll.Duration,
                    DiveDate = addDivelogFromBll.DiveDate,
                    AirTemperature = addDivelogFromBll.AirTemperature,
                    WaterTemperature = addDivelogFromBll.WaterTemperature,
                    UserId = addDivelogFromBll.UserId,
                    EventId = addDivelogFromBll.EventId,
                    MaxDeep = addDivelogFromBll.MaxDeep,
                };
            }

            internal static UpdateDivelogFormDal ToUpdateDivelogFormDal(this UpdateDivelogFormBll updateDivelogFormBll)
            {
                return new UpdateDivelogFormDal()
                {
                    Id = updateDivelogFormBll.Id,
                    Description = updateDivelogFormBll.Description,
                    DiveType = updateDivelogFormBll.DiveType,
                    Duration = updateDivelogFormBll.Duration,
                    DiveDate = updateDivelogFormBll.DiveDate,
                    AirTemperature = updateDivelogFormBll.AirTemperature,
                    WaterTemperature = updateDivelogFormBll.WaterTemperature,
                    UserId = updateDivelogFormBll.UserId,
                    EventId = updateDivelogFormBll.EventId,
                    MaxDeep = updateDivelogFormBll.MaxDeep,

                };
            }
        
    }
}
