using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Organisation;
using BLL.Models.Forms.Training;
using DAL.Interfaces;
using DAL.Models.DTO;
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
        private readonly IOrganisationBll _organisationBll;

        public TrainingBllService(ILogger<TrainingBllService> logger, ITrainingDal trainingDal, IOrganisationBll organisationBll)
        {
            _trainingDal = trainingDal;
            _logger = logger;
            _organisationBll = organisationBll;
        }

        public int? Delete(int id)
        {
            return _trainingDal.Delete(id);
        }

        public IEnumerable<TrainingBll> GetAll()
        {
            List<TrainingBll> trainings = _trainingDal.GetAll().Select(u => u.ToTrainingBll()).ToList();
            foreach (var training in trainings)
            {
                training.Organisation = _organisationBll.GetById(training.OrganisationId);
            }
            return trainings;
        }

        public TrainingBll? GetById(int id)
        {
            TrainingBll training = _trainingDal.GetById(id)?.ToTrainingBll();
            training.Organisation = _organisationBll.GetById(training.OrganisationId);
            return training;
        }

        public TrainingBll? Insert(AddTrainingFormBll form)
        {
            return _trainingDal.Insert(form.ToAddTrainingFromDal())?.ToTrainingBll();
        }

        public TrainingBll? Update(UpdateTrainingFormBll form)
        {
            return _trainingDal.Update(form.ToUpdateTrainingFormDal())?.ToTrainingBll();
        }

        public int? Disable(int id)
        {
            return _trainingDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _trainingDal.Enable(id); ;
        }
    }
}
