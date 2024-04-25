using DAL.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Tools;
using DAL.Models.Forms;
using DAL.Interfaces;
using Org.BouncyCastle.Crypto.Generators;
using DAL.Models.DTO;

namespace DAL.Services
{
    public class UserDalService : IUserDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public UserDalService(ILogger<UserDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        public IEnumerable<UserDal> GetAll()
        {
            Command command = new Command(@"SELECT Id, lastname, firstname, email, role, birthDate, createdAt, updatedAt,isActive, adress_id,guidImage, guidInsurance, guidLevel, guidCertificat, isLevelValid, medicalDateValidation, insuranceDateValidation
                                            FROM [User];", false);
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
       

      
        public UserDal? GetById(int id)
        {
            try
            {
                UserDal? user = GetUserById(id);
                if (user == null) throw new Exception("Id invalide");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }


        public UserDal? Insert(AddUserFormDal form)
        {
            Command command = new Command("INSERT INTO [User](firstname, lastname, email, passwd, role, birthDate, createdAt, isActive) OUTPUT inserted.id VALUES(@firstname, @lastname, @email,@passwd, @role, @birthDate, @createdAt, @isActive)", false);
            command.AddParameter("lastname", form.LastName);
            command.AddParameter("firstname", form.FirstName);
            command.AddParameter("email", form.Email);
            command.AddParameter("passwd", form.Password);
            command.AddParameter("role", "user");
            command.AddParameter("birthDate", form.Birthdate);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive",1);

            try
            {
               int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    UserDal? user = GetUserById(id.Value);
                    return user;
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



        public UserDal? Update(UpdateUserFormDal form)
        {
            Command command = new Command(@"UPDATE [User] SET 
                                            firstname = @firstname, 
                                            lastname=@lastname, 
                                            email=@email, 
                                            birthDate=@birthDate, 
                                            updatedAt=@updatedAt
                                        OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("lastname", form.LastName);
            command.AddParameter("firstname", form.FirstName);
            command.AddParameter("email", form.Email);
            command.AddParameter("birthDate", form.Birthdate);
            command.AddParameter("updatedAt", DateTime.Now);
      
            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                UserDal? newuser = GetUserById(resultid.Value);
                if (newuser is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return newuser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

   
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [User] WHERE Id=@Id", false);
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


        private UserDal? GetUserById(int id)
        {
            Command command = new Command(@"SELECT Id, lastname, firstname, email, role, birthDate, createdAt, updatedAt,isActive, adress_id,guidImage, guidInsurance, guidLevel, guidCertificat, isLevelValid, medicalDateValidation, insuranceDateValidation
                                            FROM [User] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToUserDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }


        public UserDal Login(LoginFormDal form)
        {
            string? passwordHash;
            Command command = new Command("SELECT passwd FROM [User] WHERE email = @Email ", false);
            command.AddParameter("Email", form.Email);
            try
            {
                passwordHash = (string?)_connection.ExecuteScalar(command);
                if (passwordHash is null) throw new Exception("l'email est invalide");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                bool verified = BCrypt.Net.BCrypt.Verify(form.Password, passwordHash);
                if (!verified) throw new Exception("Le mot de passe est invalide");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            Command command2 = new Command(@"SELECT Id, lastname, firstname, email, role, birthDate, createdAt, updatedAt,isActive, adress_id,guidImage, guidInsurance, guidLevel, guidCertificat, isLevelValid, medicalDateValidation, insuranceDateValidation
                                            FROM [User] WHERE Email = @Email", false);
            command2.AddParameter("Email", form.Email);

            try
            {
                UserDal? user = _connection.ExecuteReader(command2, dr => dr.ToUserDal()).SingleOrDefault();

                if (user is null)
                {
                    throw new Exception("L'utilisateur n'a pas été trouvé ");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int? Disable(int id)
        {
            Command command = new Command("UPDATE [User] SET isActive = @isActive WHERE Id=@Id ; ", false);
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
            Command command = new Command("UPDATE [User] SET isActive = @isActive WHERE Id=@Id ; ", false);
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

        public int? UnLike(int likerId, int likedId)
        {
            Command command = new Command("DELETE FROM [Like] WHERE liker_Id = @liker_Id AND liked_Id = @liked_Id ", false);
            command.AddParameter("liker_Id", likerId);
            command.AddParameter("liked_Id", likedId);
           
            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne == 0) throw new Exception("erreur lors de la suppression");
                return nbLigne;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public int? DeleteLike(int likerId, int likedId)
        {
            Command command = new Command(@"DELETE FROM [Like] 
                                            WHERE liker_Id = @liker_Id AND liked_Id = @liked_Id 
                                            OR liker_Id = @liked_Id AND liked_Id = @liker_Id ", false);
            command.AddParameter("liker_Id", likerId);
            command.AddParameter("liked_Id", likedId);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne == 0) throw new Exception("erreur lors de la suppression");
                return nbLigne;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }




        public int? Like(int likerId, int likedId)
        {
            Command command = new Command("INSERT INTO [Like]( liker_Id, liked_Id, createdAt) VALUES( @liker_Id, @liked_Id,@createdAt)",false);
            command.AddParameter("liker_Id", likerId);
            command.AddParameter("liked_Id", likedId);
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

        public IEnumerable<UserDal> GetLikersByUserId(int id)
        {
            Command command = new Command(
                @"SELECT Id, lastname, firstname, email, role, birthDate, [User].createdAt, [User].updatedAt,[User].isActive, adress_id,guidImage, guidInsurance, guidLevel, guidCertificat, isLevelValid, medicalDateValidation, insuranceDateValidation
                    FROM [User]
                    WHERE [User].Id In ( SELECT [Like].liker_Id 
                                            FROM[User] 
                                            JOIN dbo.[Like] ON dbo.[Like].liker_Id = [User].Id 
                                            WHERE dbo.[like].liked_Id = @id )"
                , false
            );
            command.AddParameter("id", id);
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

        public IEnumerable<UserDal> GetLikedsByUserId(int id)
        {
            Command command = new Command(
                @"SELECT Id, lastname, firstname, email, role, birthDate, [User].createdAt, [User].updatedAt,[User].isActive, adress_id,guidImage, guidInsurance, guidLevel, guidCertificat, isLevelValid, medicalDateValidation, insuranceDateValidation
                    FROM [User]
                    WHERE [User].Id In ( SELECT [Like].liked_Id 
                                            FROM[User] 
                                            JOIN dbo.[Like] ON dbo.[Like].liker_Id = [User].Id 
                                            WHERE dbo.[like].liker_Id = @id )"
                , false
            );
            command.AddParameter("id", id);
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

        public IEnumerable<UserDal> GetFriendsUserId(int id)
        {
            Command command = new Command(
                @"SELECT Id, lastname, firstname, email, role, birthDate, U.createdAt, U.updatedAt,[U].isActive, adress_id,guidImage, guidInsurance, guidLevel, guidCertificat, isLevelValid, medicalDateValidation, insuranceDateValidation
                            FROM [User] AS U
                            JOIN [Like] AS Like1 ON U.Id = Like1.liker_Id
                            JOIN [Like] AS Like2 ON U.Id = Like2.liked_Id AND Like1.liker_Id = Like2.liked_Id AND Like1.liked_Id = Like2.liker_Id
                            WHERE  Like1.liked_Id = @id"
                , false
            );
            command.AddParameter("id", id);
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

        public int? Admin(int id)
        {
            Command command = new Command("UPDATE [User] SET role = @role WHERE Id=@Id ; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("role", "admin");

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

        public int? UnAdmin(int id)
        {
            Command command = new Command("UPDATE [User] SET role = @role WHERE Id=@Id; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("role", "user");

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

      
        public int? UpdateCertificatDate(int id, string date)
        {
            Command command = new Command("UPDATE [User] SET medicalDateValidation = @medicalDateValidation WHERE Id=@Id; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("medicalDateValidation", date);

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

        public int? UpdateInsuranceDate(int id, string date)
        {
            Command command = new Command("UPDATE [User] SET insuranceDateValidation = @insuranceDateValidation WHERE Id=@Id; ", false);
            command.AddParameter("Id", id);
            command.AddParameter("insuranceDateValidation", date);

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

    }
}
