using BLL.Models.DTO;
using BLL.Models.Forms.Organisation;
using BLL.Models.Forms.Training;
using DAL.Models.DTO;
using DAL.Models.Forms.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITrainingBll
    {
        IEnumerable<TrainingBll> GetAll();

        TrainingBll? GetById(int id);

        TrainingBll? Insert(AddTrainingFormBll form);

        TrainingBll? Update(UpdateTrainingFormBll form);

        IEnumerable<TrainingBll>? GetTrainingsByUserId(int id);
        IEnumerable<TrainingBll>? GetTrainingsByOrganisationId(int id);

        IEnumerable<TrainingBll>? InsertUserTraining(UserTrainingFormBll form);

        IEnumerable<TrainingBll> Delete(int id);
        int? Enable(int id);

        int? Disable(int id);

        int? UpdateMostLevel(int id, int userId);
        int? DeleteUserTraining(int trainingId, int userId);
    }
}
