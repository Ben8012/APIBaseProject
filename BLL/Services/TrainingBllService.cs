using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Organisation;
using BLL.Models.Forms.Training;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TrainingBllService : ITrainingBll
    {

        private readonly ILogger _logger;
        private readonly ITrainingDal _trainingDal;

        public TrainingBllService(ILogger<TrainingBllService> logger, ITrainingDal trainingDal)
        {
            _trainingDal = trainingDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _trainingDal.Delete(id);
        }

        public IEnumerable<TrainingBll> GetAll()
        {
            return _trainingDal.GetAll().Select(u => u.ToTrainingBll());
        }

        public TrainingBll? GetById(int id)
        {
            return _trainingDal.GetById(id)?.ToTrainingBll();
        }

        public TrainingBll? Insert(AddTrainingFormBll form)
        {
            return _trainingDal.Insert(form.ToAddTrainingFromDal())?.ToTrainingBll();
        }

        public TrainingBll? Update(UpdateTrainingFormBll form)
        {
            return _trainingDal.Update(form.ToUpdateTrainingFormDal())?.ToTrainingBll();
        }
    }
}
