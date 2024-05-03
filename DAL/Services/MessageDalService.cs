using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Insurance;
using DAL.Models.Forms.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class MessageDalService : IMessageDal
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public MessageDalService(ILogger<MessageDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Message] WHERE Id=@Id", false);
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
            Command command = new Command("UPDATE [Message] SET isActive = @isActive WHERE Id=@Id ; ", false);
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
            Command command = new Command("UPDATE [Message] SET isActive = @isActive WHERE Id=@Id ; ", false);
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


        public IEnumerable<MessageDal> GetAll()
        {
            Command command = new Command("SELECT Id, sender_Id, reciever_Id, content, createdAt, updatedAt, isActive, isRead FROM [Message];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToMessageDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public MessageDal? GetById(int id)
        {
            try
            {
                MessageDal? message = GetMessageById(id);
                if (message == null) throw new Exception("Id invalide");
                return message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public MessageDal? Insert(AddMessageFormDal form)
        {

            Command command = new Command("INSERT INTO [Message](sender_Id, reciever_Id, content, createdAt, isActive,isRead ) OUTPUT inserted.id VALUES( @sender_Id, @reciever_Id, @content, @createdAt, @isActive, @isRead )", false);
            command.AddParameter("sender_Id", form.SenderId);
            command.AddParameter("reciever_Id", form.RecieverId);
            command.AddParameter("content", form.Content);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("isRead", 0);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    MessageDal? message = GetMessageById(id.Value);
                    return message;
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

        public MessageDal? Update(UpdateMessageFormDal form)
        {
            Command command = new Command("UPDATE [Message] SET sender_Id = @sender_Id , reciever_Id = @reciever_Id , content = @content , updatedAt = @updatedAt   OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("sender_Id", form.SenderId);
            command.AddParameter("reciever_Id", form.RecieverId);
            command.AddParameter("content", form.Content);
            command.AddParameter("updatedAt", DateTime.Now);

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                MessageDal? message = GetMessageById(resultid.Value);
                if (message is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private MessageDal? GetMessageById(int id)
        {
            Command command = new Command("SELECT Id, sender_Id, reciever_Id, content, createdAt, updatedAt, isActive, isRead FROM [Message] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToMessageDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<MessageDal>? GetMessagesBySenderId(int id)
        {
            Command command = new Command(@"SELECT Id, sender_Id, reciever_Id, content, createdAt, updatedAt, isActive, isRead 
                                            FROM [Message] 
                                            WHERE sender_Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToMessageDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<MessageDal>? GetMessagesBetween(int sender, int reciever)
        {
            Command command = new Command(@"SELECT Id, sender_Id, reciever_Id, content, createdAt, updatedAt, isActive ,isRead
                                            FROM [Message] 
                                            WHERE sender_Id = @sender AND reciever_Id = @reciever
                                            OR sender_Id = @reciever AND reciever_Id = @sender", false);
            command.AddParameter("sender", sender);
            command.AddParameter("reciever", reciever);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToMessageDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<MessageDal>? GetMessagesByRecieverId(int id)
        {
            Command command = new Command(@"SELECT Id, sender_Id, reciever_Id, content, createdAt, updatedAt, isActive , isRead
                                            FROM [Message] 
                                            WHERE reciever_Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToMessageDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public void IsRead(int friendId, int userId)
        {
            Command command = new Command(@"UPDATE [Message] SET isRead = @isRead
                                            WHERE sender_Id = @reciever  AND reciever_Id = @sender", false);
            command.AddParameter("reciever", friendId);
            command.AddParameter("sender", userId);
            command.AddParameter("isRead", 1);
         
            try
            {
                _connection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
      
    }
}
