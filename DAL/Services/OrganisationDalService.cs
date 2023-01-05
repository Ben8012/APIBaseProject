﻿using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Message;
using DAL.Models.Forms.Organisation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class OrganisationDalService : IOrganisationDal
    {

        private readonly Connection _connection;
        private readonly ILogger _logger;

        public OrganisationDalService(ILogger<OrganisationDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Organisation] WHERE Id=@Id", false);
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

        public IEnumerable<OrganisationDal> GetAll()
        {
            Command command = new Command("SELECT Id, name, picture, createdAt, updatedAt, isActive, adress_Id FROM [Organisation];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToOrganisationDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public OrganisationDal? GetById(int id)
        {

            try
            {
                OrganisationDal? organisation = GetOrganisationById(id);
                if (organisation == null) throw new Exception("Id invalide");
                return organisation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public OrganisationDal? Insert(AddOrganisationFormDal form)
        {

            Command command = new Command("INSERT INTO [Organisation](name, picture, createdAt, isActive, adress_Id) OUTPUT inserted.id VALUES(@name, @picture, @createdAt, @isActive, @adress_Id)", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("adress_Id", form.AdressId );

            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    OrganisationDal? organisation = GetOrganisationById(id.Value);
                    return organisation;
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

        public OrganisationDal? Update(UpdateOrganisationFormDal form)
        {
            Command command = new Command("UPDATE [Organisation] SET  name = @name , picture = @picture , updatedAt = @updatedAt , adress_Id = @adress_Id   OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("adress_Id", form.AdressId);

            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                OrganisationDal? organisation = GetOrganisationById(resultid.Value);
                if (organisation is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return organisation;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private OrganisationDal? GetOrganisationById(int id)
        {
            Command command = new Command("SELECT Id, name, picture, createdAt, updatedAt, isActive, adress_Id FROM [Organisation] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToOrganisationDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
