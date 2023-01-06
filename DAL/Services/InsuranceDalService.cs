using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Event;
using DAL.Models.Forms.Insurance;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class InsuranceDalService : IInsuranceDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public InsuranceDalService(ILogger<InsuranceDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }
        public int? Delete(int id)
        {
            Command command = new Command("DELETE FROM [Insurance] WHERE Id=@Id", false);
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
            Command command = new Command("UPDATE [Insurance] SET isActive = @isActive WHERE Id=@Id ; ", false);
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
            Command command = new Command("UPDATE [Insurance] SET isActive = @isActive WHERE Id=@Id ; ", false);
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

        public IEnumerable<InsuranceDal> GetAll()
        {
            Command command = new Command("SELECT Id, [name], picture, createdAt, updatedAt, isActive, adress_Id FROM [Insurance];", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToInsuranceDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public InsuranceDal? GetById(int id)
        {

            try
            {
                InsuranceDal? insurance = GetInsuranceById(id);
                if (insurance == null) throw new Exception("Id invalide");
                return insurance;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public InsuranceDal? Insert(AddInsuranceFormDal form)
        {

            Command command = new Command("INSERT INTO [Insurance](name, picture, createdAt, isActive, adress_Id ) OUTPUT inserted.id VALUES( @name, @picture, @createdAt, @isActive, @adress_Id )", false);
            command.AddParameter("name", form.Name);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("createdAt", DateTime.Now);
            command.AddParameter("isActive", 1);
            command.AddParameter("adress_Id", form.AdressId);
           
            try
            {
                int? id = (int?)_connection.ExecuteScalar(command); // recuperer l'id du contact inseré
                if (id.HasValue)
                {
                    InsuranceDal? eventD = GetInsuranceById(id.Value);
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

        public InsuranceDal? Update(UpdateInsuranceFormDal form)
        {
            Command command = new Command("UPDATE [Insurance] SET name = @name , picture = @picture , updatedAt = @updatedAt , adress_Id = @adress_Id  OUTPUT inserted.id WHERE Id=@Id ; ", false);
            command.AddParameter("Id", form.Id);
            command.AddParameter("name", form.Name);
            command.AddParameter("picture", form.Picture);
            command.AddParameter("updatedAt", DateTime.Now);
            command.AddParameter("adress_Id", form.AdressId );
          
            try
            {
                int? resultid = (int?)_connection.ExecuteScalar(command);
                if (!resultid.HasValue) throw new Exception("probleme de recuperation de l'id lors de la mise a jour");
                InsuranceDal? insurance = GetInsuranceById(resultid.Value);
                if (insurance is null) throw new Exception("probleme de recuperation de l'utilisateur lors de la mise a jour");
                return insurance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private InsuranceDal? GetInsuranceById(int id)
        {
            Command command = new Command("SELECT Id, [name], picture, createdAt, updatedAt, isActive, adress_Id FROM [Insurance] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToInsuranceDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
