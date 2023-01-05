using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Diveplace;
using DAL.Models.Forms.Event;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class EventDalService : IEventDal
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public EventDalService(ILogger<EventDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Event] WHERE Id=@Id", false);
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

        public IEnumerable<EventDal> GetAll()
        {
            Command command = new Command("SELECT Id, [name], startDate, endDate, createdAt, updatedAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id FROM [Event];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToEventDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public EventDal? GetById(int id)
        {

            try
            {
                EventDal? eventD = GetEventById(id);
                if (eventD == null) throw new Exception("Id invalide");
                return eventD;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public EventDal? Insert(AddEventFormDal form)
        {

            Command command = new Command("INSERT INTO [Event]( name, startDate, endDate, createdAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id ) OUTPUT inserted.id VALUES( @name, @startDate, @endDate, @createdAt, @isActive, @diveplace_Id, @creator_Id, @training_Id, @club_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("startDate", form.StartDate);
            command.AddParameter("endDate", form.EndDate);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("diveplace_Id", form.DiveplaceId);
            command.AddParameter("creator_Id", form.CreatorId);
            command.AddParameter("training_Id", form.TrainingId);
            command.AddParameter("club_Id", form.ClubId);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    EventDal? eventD = GetEventById(id.Value);
                    return eventD;
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

        public EventDal? Update(UpdateEventFormDal form)
        {
            Command command = new Command("UPDATE [Event] SET name = @name , startDate = @startDate , endDate = @endDate, updatedAt = @updatedAt , diveplace_Id = @diveplace_Id ,creator_Id = @creator_Id , training_Id = @training_Id ,club_Id = @club_Id  OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("startDate", form.StartDate);
            command.AddParameter("endDate", form.EndDate);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("diveplace_Id", form.DiveplaceId);
            command.AddParameter("creator_Id", form.CreatorId);
            command.AddParameter("training_Id", form.TrainingId);
            command.AddParameter("club_Id", form.ClubId);

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                EventDal? eventD = GetEventById(resultid.Value);
                if (eventD is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return eventD;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private EventDal? GetEventById(int id)
        {
            Command command = new Command("SELECT Id, [name], startDate, endDate, createdAt, updatedAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id FROM [Event] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToEventDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
