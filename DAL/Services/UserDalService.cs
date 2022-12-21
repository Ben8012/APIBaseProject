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
using DAL.Models;
using DAL.Models.Forms;
using DAL.Interfaces;
using Org.BouncyCastle.Crypto.Generators;

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
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt, UpdatedAt FROM [User];", false);
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
            Command command = new Command("SP_InsertUser", true);
            command.AddParameter("LastName", form.LastName);
            command.AddParameter("FirstName", form.FirstName);
            command.AddParameter("Email", form.Email);
            command.AddParameter("Birthdate", form.Birthdate);
            command.AddParameter("Password", form.Password);

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
            Command command = new Command($"SP_UpdateUser", true);
            command.AddParameter("Id", form.Id);
            command.AddParameter("FirstName", form.FirstName);
            command.AddParameter("Email", form.Email);
            command.AddParameter("Birthdate", form.Birthdate);
            command.AddParameter("LastName", form.LastName);

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
            Command command = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt, UpdatedAt FROM [User] WHERE Id = @Id;", false);
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
            Command command = new Command("SELECT Password FROM [User] WHERE Email = @Email ", false);
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
            
            Command command2 = new Command("SELECT Id, LastName, FirstName, Email, Birthdate, CreatedAt, UpdatedAt FROM [User] WHERE Email = @Email", false);
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

    }
}
