using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Club;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class ClubDalService : IClubDal
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public ClubDalService(ILogger<ClubDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Club] WHERE Id=@Id", false);
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
            Command command = new Command("UPDATE [Club] SET isActive = @isActive WHERE Id=@Id ; ", false);
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
            Command command = new Command("UPDATE [Club] SET isActive = @isActive WHERE Id=@Id ; ", false);
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

        public IEnumerable<ClubDal> GetAll()
        {
            Command command = new Command("SELECT Id, name, createdAt, updatedAt, isActive, adress_Id, creator_Id FROM [Club];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToClubDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public ClubDal? GetById(int id)
        {

            try
            {
                ClubDal? club = GetClubById(id);
                if (club == null) throw new Exception("Id invalide");
                return club;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public ClubDal? Insert(AddClubFormDal form)
        {

            Command command = new Command("INSERT INTO [Club](name, createdAt, isActive,creator_Id, adress_Id) OUTPUT inserted.id VALUES(@name, GETDATE(), 1,@creator_Id , @adress_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("adress_Id", form.AdressId);
            command.AddParameter("creator_Id", form.CreatorId);
           
            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    ClubDal? club = GetClubById(id.Value);
                    return club;
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

        public int? Participate(int userId, int clubId)
        {
            Command command = new Command("INSERT INTO [User_Club]( user_Id, club_Id, createdAt) VALUES( @user_Id, @club_Id, @createdAt)", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("club_Id", clubId);
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

        public int? UnParticipate(int userId, int clubId)
        {
            Command command = new Command("DELETE FROM [User_Club] WHERE user_Id = @user_Id AND club_Id = @club_Id", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("club_Id", clubId);
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


        public ClubDal? Update(UpdateClubFormDal form)
        {
            Command command = new Command("UPDATE [Club] SET name = @name, adress_Id=@adress_Id, creator_Id=@creator_ID OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("adress_Id", form.AdressId);
            command.AddParameter("creator_Id", form.CreatorId);
           
            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                ClubDal? club = GetClubById(resultid.Value);
                if (club is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return club;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       


        private ClubDal? GetClubById(int id)
        {
            Command command = new Command("SELECT Id, name, createdAt, updatedAt, isActive,  adress_id, creator_id FROM [Club] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToClubDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

    }
}
