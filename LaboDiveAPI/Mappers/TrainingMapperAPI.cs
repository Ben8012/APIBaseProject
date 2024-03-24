using API.Models.DTO;
using API.Models.Forms.Organisation;
using API.Models.Forms.Training;
using BLL.Models.DTO;
using BLL.Models.Forms.Organisation;
using BLL.Models.Forms.Training;

namespace API.Mappers
{
    public static class TrainingMapperAPI
    {
        internal static Training ToTraining(this TrainingBll trainingBll)
        {
            return new Training()
            {
               Id= trainingBll.Id,
               Name=trainingBll.Name,
               Prerequisite=trainingBll.Prerequisite,
               Picture=trainingBll.Picture,
               IsSpeciality=trainingBll.IsSpeciality,
               CreatedAt=trainingBll.CreatedAt,
               UpdatedAt=trainingBll.UpdatedAt,
               IsActive=trainingBll.IsActive,
               Organisation = trainingBll.Organisation is null ? null : trainingBll.Organisation.ToOrganisation(),
               Description = trainingBll.Description,
            };
        }

        internal static AddTrainingFormBll ToAddTrainingFromBll(this AddTrainingForm addTrainingFrom)
        {
            return new AddTrainingFormBll()
            {
                Name = addTrainingFrom.Name,
                Prerequisite = addTrainingFrom.Prerequisite,
                Picture = addTrainingFrom.Picture,
                IsSpeciality = addTrainingFrom.IsSpeciality,
                OrganisationId = addTrainingFrom.OrganisationId,
                Description = addTrainingFrom.Description,
            };
        }

        internal static UpdateTrainingFormBll ToUpdateTrainingFormBll(this UpdateTrainingForm updateTrainingForm)
        {
            return new UpdateTrainingFormBll()
            {
                Id = updateTrainingForm.Id,
                Name = updateTrainingForm.Name,
                Prerequisite = updateTrainingForm.Prerequisite,
                Picture = updateTrainingForm.Picture,
                IsSpeciality = updateTrainingForm.IsSpeciality,
                OrganisationId = updateTrainingForm.OrganisationId,
                Description = updateTrainingForm.Description,
            };
        }
    }
}
