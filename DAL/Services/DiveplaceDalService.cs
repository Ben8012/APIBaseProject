﻿using DAL.Interfaces;
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
            Command command = new Command("SELECT Id, name, picture, map, description, createdAt, updatedAt, isActive, adress_Id FROM [Diveplace];", false);
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

        public DiveplaceDal? Insert(AddDiveplaceFormDal form)
        {

            Command command = new Command("INSERT INTO [Diveplace]( name, picture, map, description, createdAt, isActive, adress_Id ) OUTPUT inserted.id VALUES( @name, @picture, @map, @description, @createdAt, @isActive, @adress_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("map", form.Map);
            command.AddParameter("description", form.Description);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("adress_Id", form.AdressId);     

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    DiveplaceDal? divelog = GetDiveplaceById(id.Value);
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

        public DiveplaceDal? Update(UpdateDiveplaceFormDal form)
        {
            Command command = new Command("UPDATE [Diveplace] SET [name] = @name , picture = @picture , map = @map , description = @description , updatedAt = @updatedAt , adress_Id = @adress_Id  OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("map", form.Map);
            command.AddParameter("description", form.Description);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("adress_Id", form.AdressId);
         


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

        public int? Vote(int userId, int diveplaceId, int vote)
        {
            Command command = new Command("INSERT INTO [User_Diveplace](user_Id, diveplace_Id,evaluation, createdAt ) VALUES( @user_Id, @diveplace_Id,@evaluation, @createdAt )", false);
            command.AddParameter("user_Id", userId);
            command.AddParameter("diveplace_Id", diveplaceId);
            command.AddParameter("evaluation", vote);
            command.AddParameter("createdAt", DateTime.Now);

            try
            {
                int? nbLigne = (int?)_connection.ExecuteNonQuery(command);
                if (nbLigne != 1) throw new Exception("erreur lors de la l'insertion du vote");
                return nbLigne;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DiveplaceDal? GetDiveplaceById(int id)
        {
            Command command = new Command("SELECT Id, [name], picture, map, description, createdAt, updatedAt, isActive, adress_Id FROM [Diveplace] WHERE Id = @Id;", false);
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
    }
}
