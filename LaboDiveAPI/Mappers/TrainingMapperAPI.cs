﻿using API.Models.DTO;
using API.Models.Forms.Organisation;
using API.Models.Forms.Training;
using BLL.Models.DTO;
using BLL.Models.Forms.Organisation;
using BLL.Models.Forms.Training;
using DAL.Models.DTO;

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
               Prerequis=trainingBll.Prerequis is null ? null : trainingBll.Prerequis.ToTraining(),
               GuidImage =trainingBll.GuidImage,
               IsSpeciality=trainingBll.IsSpeciality,
               CreatedAt=trainingBll.CreatedAt,
               UpdatedAt=trainingBll.UpdatedAt,
               IsActive=trainingBll.IsActive,
               Organisation = trainingBll.Organisation is null ? null : trainingBll.Organisation.ToOrganisation(),
               Description = trainingBll.Description,
               RefNumber = trainingBll.RefNumber,
               IsMostLevel = trainingBll.IsMostLevel,
            };
        }

        internal static AddTrainingFormBll ToAddTrainingFromBll(this AddTrainingForm addTrainingFrom)
        {
            return new AddTrainingFormBll()
            {
                Name = addTrainingFrom.Name,
                PrerequisId = addTrainingFrom.PrerequisId,
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
                PrerequisId = updateTrainingForm.PrerequisId,
                IsSpeciality = updateTrainingForm.IsSpeciality,
                OrganisationId = updateTrainingForm.OrganisationId,
                Description = updateTrainingForm.Description,
            };
        }

        internal static UserTrainingFormBll ToUserTrainingFromBll(this UserTrainingForm form)
        {
            return new UserTrainingFormBll()
            {
                Id = form.Id,
                UserId= form.UserId,
                IsMostlevel = form.IsMostlevel,
                TrainingId= form.TrainingId,
                RefNumber= form.RefNumber,
            };
        }

    }
}
