using DAL.Models.DTO;
using DAL.Models.Forms.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITrainingDal
    {
        IEnumerable<TrainingDal> GetAll();
        TrainingDal? GetById(int id);
        TrainingDal? Insert(AddTrainingFormDal form);
        TrainingDal? Update(UpdateTrainingFormDal form);

        IEnumerable<TrainingDal>? GetTrainingsByUserId(int id);
        IEnumerable<TrainingDal>? GetTrainingsByOrganisationId(int id);

        IEnumerable<TrainingDal>? InsertUserTraining(UserTrainingFormDal form);

        int? Delete(int id);
        int? Enable(int id);
        int? Disable(int id);

        int? UpdateMostLevel(int id);
        int? DeleteUserTraining(int trainingId, int userId);
    }
}
