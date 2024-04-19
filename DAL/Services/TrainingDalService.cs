using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Organisation;
using DAL.Models.Forms.Training;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class TrainingDalService : ITrainingDal
    {


        private readonly Connection _connection;
        private readonly ILogger _logger;

        public TrainingDalService(ILogger<TrainingDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Training] WHERE Id=@Id", false);
            command.AddParameter("Id", id);
            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de la suppression");
                return nbLigne;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public int? Disable(int id)
        {
            Command command = new Command("UPDATE [Training] SET isActive = @isActive WHERE Id=@Id ; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("isActive", 0);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de la suppression");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? Enable(int id)
        {
            Command command = new Command("UPDATE [Training] SET isActive = @isActive WHERE Id=@Id ; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("isActive", 1);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de la suppression");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<TrainingDal> GetAll()
        {
            Command command = new Command("SELECT Id, name, prerequis, picture, isSpeciality,[description], createdAt, updatedAt, isActive, organisation_Id FROM [Training];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToTrainingDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public TrainingDal? GetById(int id)
        {

            try
            {
                TrainingDal? training = GetTrainingById(id);
                if (training == null) throw new Exception("Id invalide");
                return training;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public TrainingDal? Insert(AddTrainingFormDal form)
        {

            Command command = new Command("INSERT INTO [Training](name, prerequis, picture, isSpeciality,[description], createdAt, isActive, organisation_Id) OUTPUT inserted.id VALUES(@name, @prerequis, @picture, @isSpeciality, @createdAt, @isActive, @organisation_Id)", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("prerequis", form.Prerequisite);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("isSpeciality", form.IsSpeciality);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("organisation_Id", form.OrganisationId);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    TrainingDal? training = GetTrainingById(id.Value);
                    return training;
                }
                else
                {
                    throw new Exception("probleme de recuperation de l'id lors de l'insertion");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrainingDal? Update(UpdateTrainingFormDal form)
        {
            Command command = new Command("UPDATE [Training] SET name = @name , [description] = @description, prerequis = @prerequis , picture = @picture , isSpeciality = @isSpeciality, updatedAt = @updatedAt , organisation_Id = @organisation_Id  OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("prerequis", form.Prerequisite);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("isSpeciality", form.IsSpeciality);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("organisation_Id", form.OrganisationId);
            command.AddParameter("description", form.Description);

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                TrainingDal? training = GetTrainingById(resultid.Value);
                if (training is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return training;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private TrainingDal? GetTrainingById(int id)
        {
            Command command = new Command("SELECT Id, name, prerequis, picture, isSpeciality, [description], createdAt, updatedAt, isActive, organisation_Id  FROM [Training] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToTrainingDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<TrainingDal>? GetTrainingsByUserId(int id)
        {
            Command command = new Command(@"SELECT Id, name, prerequis, picture, isSpeciality, [description], [Training].createdAt, updatedAt, isActive, organisation_Id,refNumber, isMostLevel   
                                            FROM [Training] 
                                            JOIN [User_Training] ON [Training].Id = [User_Training].training_Id
                                            WHERE [User_Training].user_Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToTrainingByUserDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
