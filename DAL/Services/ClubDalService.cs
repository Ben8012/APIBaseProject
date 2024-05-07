using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Club;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
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
            Command command = new Command(@"SELECT Id, name, createdAt, updatedAt, isActive, adress_Id, creator_Id 
                                            FROM [Club] WHERE isActive = 1 ;", false);
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

        public ClubDal? Insert(ClubFormDal form)
        {
           
            Command command = new Command("INSERT INTO [Club](name, createdAt, isActive,creator_Id, adress_Id) OUTPUT inserted.id VALUES(@name, GETDATE(), 1,@creator_Id , @adress_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("adress_Id", form.AdressId);
            command.AddParameter("creator_Id", form.CreatorId);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    ClubDal? club = GetClubById(id.Value);
                    Participate(form.CreatorId, club.Id);
                    ValidationParticipate(form.CreatorId, club.Id);
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
            Command command = new Command("INSERT INTO [User_Club]( user_Id, club_Id, createdAt, validation) VALUES( @user_Id, @club_Id, @createdAt, @validation)", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("club_Id", clubId);
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

        public int? ValidationParticipate(int userId, int clubId)
        {
            Command command = new Command("UPDATE [User_Club] SET validation = @validation WHERE user_Id=@user_Id AND club_Id=@club_Id", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("club_Id", clubId);
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

        public int? UnValidationParticipate(int userId, int clubId)
        {
            Command command = new Command("UPDATE [User_Club] SET validation = @validation WHERE user_Id=@user_Id AND club_Id=@club_Id", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("club_Id", clubId);
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


        public ClubDal? Update(ClubFormDal form)
        {
            //adress_Id=@adress_Id, 
            Command command = new Command(@"UPDATE [Club] SET 
                                            name = @name, 
                                            creator_Id = @creator_Id,
                                            updatedAt = @updatedAt,
                                            adress_Id = @adress_Id
                                            OUTPUT inserted.id 
                                            WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("adress_Id", form.AdressId);
            command.AddParameter("creator_Id", form.CreatorId);
            command.AddParameter("updatedAt", DateTime.Now);

            try
            {
                int resultid = (int)_connection.ExecuteScalar(command);
                ClubDal? club = GetClubById(resultid);
                if (club is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return club;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<ClubDal>? GetClubsByUserId(int id)
        {
            Command command = new Command(@"SELECT Club.Id, [name], Club.createdAt as createdAt, Club.updatedAt as updatedAt , Club.isActive as isActive,  Club.adress_id as adress_id , Club.creator_id as creator_id 
                                            FROM [Club]
                                            JOIN User_Club ON Club.Id = User_Club.club_Id
                                            JOIN [User] ON [User].Id = User_Club.user_Id
                                                OR [User].Id = [Club].creator_Id
                                            WHERE [User].Id = @Id AND [Club].isActive = 1 OR [Club].creator_Id = @Id AND [Club].isActive=1;", false);
            command.AddParameter("Id", id);
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


        private ClubDal? GetClubById(int id)
        {
            Command command = new Command(@"SELECT Id, name, createdAt, updatedAt, isActive,  adress_id, creator_id 
                                            FROM [Club] 
                                            WHERE Id = @Id AND [Club].isActive = 1;", false);
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

        public IEnumerable<UserDal> GetAllDemandsByClubId(int id)
        {
            Command command = new Command(@"SELECT [User].Id, [User].lastname, [User].firstname, [User].email, [User].role, [User].birthDate, [User].createdAt, [User].updatedAt,[User].isActive, [User].adress_id, [User].guidImage, [User].guidInsurance, [User].guidLevel, [User].guidCertificat, [User].isLevelValid, [User].medicalDateValidation, [User].insuranceDateValidation
                                            FROM [User]
                                            JOIN [User_Club] ON [User_Club].[user_Id] = [User].Id
                                            JOIN [Club] ON [User_Club].[club_Id] = [Club].Id
                                            WHERE [Club].Id = @Id AND [User_Club].validation = 0 AND [Club].isActive = 1;", false);
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

        public IEnumerable<UserDal> GetAllParticipeByClubId(int id)
        {
            Command command = new Command(@"SELECT [User].Id, [User].lastname, [User].firstname, [User].email, [User].role, [User].birthDate, [User].createdAt, [User].updatedAt, [User].isActive, [User].adress_id, [User].guidImage, [User].guidInsurance, [User].guidLevel, [User].guidCertificat, [User].isLevelValid, [User].medicalDateValidation, [User].insuranceDateValidation
                                            FROM [User]
                                            JOIN [User_Club] ON [User_Club].[user_Id] = [User].Id
                                            JOIN [Club] ON [User_Club].[club_Id] = [Club].Id
                                            WHERE [Club].Id = @Id AND [User_Club].validation = 1 AND [Club].isActive = 1;", false);
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

    }
}
