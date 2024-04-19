using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Divelog;
using DAL.Models.Forms.Diveplace;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools;

namespace DAL.Services
{
    public class DiveplaceDalService : IDiveplaceDal
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public DiveplaceDalService(ILogger<DivelogDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Diveplace] WHERE Id=@Id", false);
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
            Command command = new Command("UPDATE [Diveplace] SET isActive = @isActive WHERE Id=@Id ; ", false);
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
            Command command = new Command("UPDATE [Diveplace] SET isActive = @isActive WHERE Id=@Id ; ", false);
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

  
        public IEnumerable<DiveplaceDal> GetAll()
        {
            Command command = new Command("SELECT Id, creator_Id, name, url, guidImage, guidMap, description, gps, maxDepp, price, compressor, restoration,  createdAt, updatedAt, isActive, adress_Id FROM [Diveplace];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToDiveplaceDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public DiveplaceDal? GetById(int id)
        {

            try
            {
                DiveplaceDal? diveplace = GetDiveplaceById(id);
                if (diveplace == null) throw new Exception("Id invalide");
                return diveplace;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public DiveplaceDal? Insert(DiveplaceFormDal form)
        {

            Command command = new Command(@"INSERT INTO [Diveplace]
                ( name,creator_Id, description, gps, maxDepp, price, compressor,url, restoration, createdAt, isActive, adress_Id ) 
                OUTPUT inserted.id 
                VALUES( @name,@creator_Id, @description, @gps, @maxDepp, @price, @compressor, @url, @restoration, @createdAt, @isActive, @adress_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("description", form.Description);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("adress_Id", form.AdressId);     
            command.AddParameter("gps", form.Gps);     
            command.AddParameter("maxDepp", form.MaxDeep);     
            command.AddParameter("price", form.Price);     
            command.AddParameter("compressor", form.Compressor);
            command.AddParameter("restoration", form.Restoration);
            command.AddParameter("url", form.Url);
            command.AddParameter("creator_Id", form.CreatorId);

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    Command command2 = new Command(@"INSERT INTO [User_Diveplace](user_Id, diveplace_Id,evaluation, createdAt ) 
                                                    VALUES( @user_Id, @diveplace_Id,@evaluation, @createdAt )", false);
                    command2.AddParameter("user_Id", form.CreatorId);
                    command2.AddParameter("diveplace_Id", id);
                    command2.AddParameter("evaluation", 0);
                    command2.AddParameter("createdAt", DateTime.Now);
                    int? nbLigne = (int?)_connection.ExecuteNonQuery(command2);
                    DiveplaceDal? diveplace = GetDiveplaceById(id.Value);
                    
                    return diveplace;
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

        public DiveplaceDal? Update(DiveplaceFormDal form)
        {
            Command command = new Command(@"UPDATE [Diveplace] SET 
                                            [name] = @name, 
                                            creator_Id = @creator_Id,
                                            description = @description,
                                            gps = @gps,
                                            maxDepp = @maxDepp,
                                            price = @price,
                                            compressor = @compressor,
                                            restoration = @restoration, 
                                            updatedAt = @updatedAt , 
                                            url = @url, 
                                            adress_Id = @adress_Id  
                                            OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("description", form.Description);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("adress_Id", form.AdressId);
            command.AddParameter("gps", form.Gps);
            command.AddParameter("maxDepp", form.MaxDeep);
            command.AddParameter("price", form.Price);
            command.AddParameter("compressor", form.Compressor);
            command.AddParameter("restoration", form.Restoration);
            command.AddParameter("url", form.Url);
            command.AddParameter("creator_Id", form.CreatorId);

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                DiveplaceDal? diveplace = GetDiveplaceById(resultid.Value);
                if (diveplace is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return diveplace;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DiveplaceDal> Vote(int userId, int diveplaceId, int vote)
        {
            int? oldVote;
            Command command1 = new Command(@"SELECT evaluation
                                            FROM [User_Diveplace] 
                                            WHERE user_Id = @userId AND diveplace_Id = @diveplaceId ;", false);
            command1.AddParameter("userId", userId);
            command1.AddParameter("diveplaceId", diveplaceId);
            try
            {
                oldVote = (int?)_connection.ExecuteScalar(command1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
           
            if (!oldVote.HasValue)
            {

                Command command = new Command(@"INSERT INTO [User_Diveplace](user_Id, diveplace_Id,evaluation, createdAt ) 
                                                    VALUES( @user_Id, @diveplace_Id,@evaluation, @createdAt )", false);
                command.AddParameter("user_Id", userId);
                command.AddParameter("diveplace_Id", diveplaceId);
                command.AddParameter("evaluation", vote);
                command.AddParameter("createdAt", DateTime.Now);
                try
                {
                    int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                    if (nbLigne != 1) throw new Exception("erreur lors de la l'insertion du vote");
                    return GetAll().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Command command = new Command(@"UPDATE  [User_Diveplace] SET [evaluation] = @evaluation
                                                WHERE user_Id = @user_Id AND diveplace_Id = @diveplace_Id", false);
                command.AddParameter("user_Id", userId);
                command.AddParameter("diveplace_Id", diveplaceId);
                command.AddParameter("evaluation", vote);
                try
                {
                    int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                    if (nbLigne != 1) throw new Exception("erreur lors de la l'insertion du vote");
                    return GetAll().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }    
        }

        private DiveplaceDal? GetDiveplaceById(int id)
        {
            Command command = new Command(@"SELECT Id, creator_Id, url, [name], guidImage, guidMap, description, gps, maxDepp, price, compressor, restoration, url, createdAt, updatedAt, isActive, adress_Id FROM [Diveplace] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToDiveplaceDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public IEnumerable<DiveplaceDal>? GetDiveplaceByUserId(int id)
        {
            Command command = new Command(@"SELECT [Diveplace].Id, [Diveplace].creator_Id, [name],evaluation, [Diveplace].guidImage, [Diveplace].guidMap, description, gps, maxDepp, price, compressor, restoration, [Diveplace].url, [Diveplace].createdAt, [Diveplace].updatedAt, [Diveplace].isActive, [Diveplace].adress_Id 
                                            FROM [Diveplace] 
                                            JOIN User_Diveplace ON User_Diveplace.diveplace_Id = Diveplace.Id
                                            JOIN [User] ON [User].Id = User_Diveplace.user_Id
                                            WHERE [User].Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToDiveplaceDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public int GetVoteAverageByDiveplaceId(int diveplaceId)
        {
            Command command = new Command(@"SELECT AVG(evaluation)
                                            FROM [User_Diveplace] 
                                            WHERE diveplace_Id = @diveplace_Id;", false);
            command.AddParameter("diveplace_Id", diveplaceId);
            try
            {
                int vote = (int)_connection.ExecuteScalar(command);
                return vote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public int GetVoteByUserIdAndDiveplaceId(int userId,int diveplaceId)
        {
            Command command = new Command(@"SELECT evaluation
                                            FROM [User_Diveplace] 
                                            WHERE diveplace_Id = @diveplace_Id AND user_Id = @user_Id", false);
            command.AddParameter("diveplace_Id", diveplaceId);
            command.AddParameter("user_Id", userId);
            try
            {
                var vote = (int?)_connection.ExecuteScalar(command);
                
                return vote is null ? -1 : (int)vote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
