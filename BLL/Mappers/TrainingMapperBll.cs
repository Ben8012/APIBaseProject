using BLL.Models.DTO;
using BLL.Models.Forms.Training;
using DAL.Models.DTO;
using DAL.Models.Forms.Training;

namespace BLL.Mappers
{
    public static class TrainingMapperBll
    {
        internal static TrainingBll ToTrainingBll(this TrainingDal trainingDal)
        {
            return new TrainingBll()
            {
                Id = trainingDal.Id,
                Name = trainingDal.Name,
                Prerequisite = trainingDal.Prerequisite,
                Picture = trainingDal.Picture,
                IsSpeciality = trainingDal.IsSpeciality,
                CreatedAt = trainingDal.CreatedAt,
                UpdatedAt = trainingDal.UpdatedAt,
                IsActive = trainingDal.IsActive,
                OrganisationId = trainingDal.OrganisationId,
                Description = trainingDal.Description,
            };
        }

        internal static AddTrainingFormDal ToAddTrainingFromDal(this AddTrainingFormBll addTrainingFromBll)
        {
            return new AddTrainingFormDal()
            {
                Name = addTrainingFromBll.Name,
                Prerequisite = addTrainingFromBll.Prerequisite,
                Picture = addTrainingFromBll.Picture,
                IsSpeciality = addTrainingFromBll.IsSpeciality,
                OrganisationId = addTrainingFromBll.OrganisationId,
                Description = addTrainingFromBll.Description,
            };
        }

        internal static UpdateTrainingFormDal ToUpdateTrainingFormDal(this UpdateTrainingFormBll updateTrainingFormBll)
        {
            return new UpdateTrainingFormDal()
            {
                Id = updateTrainingFormBll.Id,
                Name = updateTrainingFormBll.Name,
                Prerequisite = updateTrainingFormBll.Prerequisite,
                Picture = updateTrainingFormBll.Picture,
                IsSpeciality = updateTrainingFormBll.IsSpeciality,
                OrganisationId = updateTrainingFormBll.OrganisationId,
                Description = updateTrainingFormBll.Description,
            };
        }
    }
}
