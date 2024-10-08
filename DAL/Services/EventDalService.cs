﻿using DAL.Interfaces;
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

                Command command2 = new Command("DELETE FROM [Participe] WHERE event_Id=@Id", false);
                command2.AddParameter("Id", id);

                int? nbLigne2 = (int?)_connection.ExecuteNonQuery(command2);

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
            Command command = new Command("UPDATE [Event] SET isActive = @isActive, updatedAt = @updatedAt WHERE Id=@Id ; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("isActive", 0);
            command.AddParameter("updatedAt", DateTime.Now);

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
            Command command = new Command("UPDATE [Event] SET isActive = @isActive, updatedAt = @updatedAt WHERE Id=@Id ; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("isActive", 1);
            command.AddParameter("updatedAt", DateTime.Now);

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

        public IEnumerable<EventDal> GetAll()
        {
            Command command = new Command(@"SELECT Id, [name], startDate, endDate, createdAt, updatedAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id 
                                            FROM [Event]
                                            WHERE isActive=1;", false);
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
            int id;
            Command command = new Command("INSERT INTO [Event]( name, startDate, endDate, createdAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id ) OUTPUT inserted.id VALUES( @name, @startDate, @endDate, @createdAt, @isActive, @diveplace_Id, @creator_Id, @training_Id, @club_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("startDate", form.StartDate);
            command.AddParameter("endDate", form.EndDate);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("diveplace_Id", form.DiveplaceId);
            command.AddParameter("creator_Id", form.CreatorId);
            command.AddParameter("training_Id", form.TrainingId == 0 ? null : form.TrainingId);
            command.AddParameter("club_Id", form.ClubId == 0 ? null : form.ClubId);

            try
            {
                id = (int)_connection.ExecuteScalar(command); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Command command1 = new Command("INSERT INTO [Participe]( user_Id, event_Id, createdAt, validation) VALUES( @user_Id, @event_Id, @createdAt , @validation)", false);
            command1.AddParameter("user_Id", form.CreatorId);
            command1.AddParameter("event_Id", id);
            command1.AddParameter("createdAt", DateTime.Now);
            command1.AddParameter("validation", 1);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command1);
                if (nbLigne != 1) throw new Exception("erreur lors de l'insertion");
                EventDal? eventD = GetEventById(id);
                return eventD;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public EventDal? Update(UpdateEventFormDal form)
        {
            Command command = new Command(@"UPDATE [Event] SET 
                                            name = @name, 
                                            startDate = @startDate, 
                                            endDate = @endDate, 
                                            updatedAt = @updatedAt, 
                                            diveplace_Id = @diveplace_Id,
                                            creator_Id = @creator_Id, 
                                            training_Id = @training_Id,
                                            club_Id = @club_Id  
                                         OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("startDate", form.StartDate);
            command.AddParameter("endDate", form.EndDate);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("diveplace_Id", form.DiveplaceId);
            command.AddParameter("creator_Id", form.CreatorId);
            command.AddParameter("training_Id", form.TrainingId == 0 ? null : form.TrainingId);
            command.AddParameter("club_Id", form.ClubId == 0 ? null : form.ClubId);

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

        public int? Participate(int userId, int eventId)
        {
            Command command = new Command(@"INSERT INTO [Participe]( user_Id, event_Id, createdAt, validation) 
                                            VALUES( @user_Id, @event_Id, @createdAt, @validation)", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("event_Id", eventId);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("validation", 0);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de l'insertion");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? UnInvite(int inviterId, int invitedId, int eventId)
        {
            Command command = new Command("DELETE FROM [Invite] WHERE inviter_Id = @inviter_Id AND invited_Id = @invited_Id  AND event_Id = @event_Id", false);
            command.AddParameter("inviter_Id", inviterId);
            command.AddParameter("invited_Id", invitedId);
            command.AddParameter("event_Id", eventId);
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


        public int? Invite(int inviterId, int invitedId, int eventId)
        {
            Command command = new Command("INSERT INTO [Invite]( inviter_Id, invited_Id, event_Id, createdAt) VALUES( @inviter_Id, @invited_Id, @event_Id, @createdAt)", false);
            command.AddParameter("inviter_Id", inviterId);
            command.AddParameter("invited_Id", invitedId);
            command.AddParameter("event_Id", eventId);
            command.AddParameter("createdAt", DateTime.Now);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de l'insertion");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? UnParticipate(int userId, int eventId)
        {
            Command command = new Command("DELETE FROM [Participe] WHERE user_Id = @user_Id AND event_Id = @event_Id", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("event_Id", eventId);
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


        private EventDal? GetEventById(int id)
        {
            Command command = new Command(@"SELECT Id, [name], startDate, endDate, createdAt, updatedAt, isActive, diveplace_Id,creator_Id, training_Id ,club_Id 
                                            FROM [Event] 
                                            WHERE Id = @Id AND isActive=1;", false);
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

        public IEnumerable<EventDal> GetEventByUserId(int id)
        {
            Command command = new Command(@"SELECT Distinct [Event].Id, [name], startDate, endDate, [Event].createdAt, [Event].updatedAt, [Event].isActive, diveplace_Id,creator_Id, training_Id ,club_Id 
                                            FROM [Event]
                                            JOIN Participe ON Participe.event_Id = [Event].Id
                                            JOIN [User] ON [User].Id = Participe.user_Id
                                                OR [User].Id = [Event].creator_Id
                                            WHERE [User].Id = @Id AND [Event].isActive = 1 OR [Event].creator_Id = @Id AND [Event].isActive=1;", false);
            command.AddParameter("Id", id);
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

        public IEnumerable<UserDal> GetAllParticipeByEventId(int id)
        {
            Command command = new Command(@"SELECT [User].Id, [User].lastname, [User].firstname, [User].email , [User].role, [User].birthDate, [User].createdAt, [User].updatedAt,[User].isActive, [User].adress_id ,[User].guidImage, [User].guidInsurance, [User].guidLevel, [User].guidCertificat , [User].isLevelValid, [User].medicalDateValidation, [User].insuranceDateValidation
                                            FROM [User]
                                            JOIN Participe ON Participe.[user_Id] = [User].Id
                                            JOIN [Event] ON [Participe].[event_Id] = [Event].Id
                                            WHERE [Event].Id = @Id AND [User].isActive=1 AND Participe.validation = 1;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToUserDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<UserDal> GetAllDemandsByEventId(int id)
        {
            Command command = new Command(@"SELECT [User].Id, lastname, firstname, email, role, birthDate, [User].createdAt, [User].updatedAt,[User].isActive, [User].adress_id ,guidImage, guidInsurance, guidLevel, guidCertificat , isLevelValid, medicalDateValidation, insuranceDateValidation
                                            FROM [User]
                                            JOIN Participe ON Participe.[user_Id] = [User].Id
                                            JOIN [Event] ON [Participe].[event_Id] = [Event].Id
                                            WHERE [Event].Id = @Id AND [User].isActive=1 AND Participe.validation = 0;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToUserDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

      
        public int? ValidationParticipate(int userId, int eventId)
        {
            Command command = new Command(@"UPDATE [Participe] SET validation = @validation 
                                           WHERE user_Id = @user_Id AND event_Id = @event_Id", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("event_Id", eventId);
            command.AddParameter("validation", 1);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de l'insertion");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? UnValidationParticipate(int userId, int eventId)
        {
            Command command = new Command(@"UPDATE [Participe] SET validation = @validation
                                           WHERE user_Id = @user_Id AND event_Id = @event_Id", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("event_Id", eventId);
            command.AddParameter("validation", 0);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de l'insertion");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
