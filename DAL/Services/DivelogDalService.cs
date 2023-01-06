using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Club;
using DAL.Models.Forms.Divelog;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class DivelogDalService : IDivelogDal
    {


        private readonly Connection _connection;
        private readonly ILogger _logger;

        public DivelogDalService(ILogger<DivelogDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Divelog] WHERE Id=@Id", false);
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
            Command command = new Command("UPDATE [Divelog] SET isActive = @isActive WHERE Id=@Id ; ", false);
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
            Command command = new Command("UPDATE [Divelog] SET isActive = @isActive WHERE Id=@Id ; ", false);
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

        public IEnumerable<DivelogDal> GetAll()
        {
            Command command = new Command("SELECT Id, diveType, description, duration, maxDeep, airTemperature, waterTemperature, diveDate, createdAt, updatedAt, isActive, user_Id, event_Id FROM [Divelog];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToDivelogDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public DivelogDal? GetById(int id)
        {

            try
            {
                DivelogDal? divelog = GetDivelogById(id);
                if (divelog == null) throw new Exception("Id invalide");
                return divelog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public DivelogDal? Insert(AddDivelogFormDal form)
        {

            Command command = new Command("INSERT INTO [Divelog]( diveType, description, duration, maxDeep, airTemperature, waterTemperature, diveDate, createdAt, isActive, user_Id, event_Id) OUTPUT inserted.id VALUES( @diveType, @description, @duration, @maxDeep, @airTemperature, @waterTemperature, @diveDate, @createdAt, @isActive, @user_Id, @event_Id )", false);
            command.AddParameter("diveType", form.DiveType);
            command.AddParameter("description", form.Description);
            command.AddParameter("duration", form.Duration);
            command.AddParameter("maxDeep", form.MaxDeep);
            command.AddParameter("airTemperature", form.AirTemperature);
            command.AddParameter("waterTemperature", form.WaterTemperature);
            command.AddParameter("diveDate", form.DiveDate);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("user_Id", form.UserId);
            command.AddParameter("event_Id", form.EventId);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    DivelogDal? divelog = GetDivelogById(id.Value);
                    return divelog;
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

        public DivelogDal? Update(UpdateDivelogFormDal form)
        {
            Command command = new Command("UPDATE [Divelog] SET diveType = @diveType, description = @description, duration = @duration, maxDeep = @maxDeep, airTemperature = @airTemperature , waterTemperature = @waterTemperature , diveDate = @diveDate , updatedAt = @updatedAt, user_Id = @user_Id, event_Id = @event_Id  OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("diveType", form.DiveType);
            command.AddParameter("description", form.Description);
            command.AddParameter("duration", form.Duration);
            command.AddParameter("maxDeep", form.MaxDeep);
            command.AddParameter("airTemperature", form.AirTemperature);
            command.AddParameter("waterTemperature", form.WaterTemperature);
            command.AddParameter("diveDate", form.DiveDate);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("user_Id", form.UserId);
            command.AddParameter("event_Id", form.EventId);
            

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                DivelogDal? divelog = GetDivelogById(resultid.Value);
                if (divelog is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return divelog;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private DivelogDal? GetDivelogById(int id)
        {
            Command command = new Command("SELECT Id, diveType, description, duration, maxDeep, airTemperature, waterTemperature, diveDate, createdAt, updatedAt, isActive, user_Id, event_Id FROM [Divelog] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToDivelogDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
