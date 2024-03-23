using DAL.Interfaces;
using DAL.Mappers;
using DAL.Models.DTO;
using DAL.Models.Forms.Adress;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL.Services
{
    public class AdressDalService : IAdressDal
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public AdressDalService(ILogger<AdressDalService> logger, Connection connection)
        {
            _connection = connection;
            _logger = logger;
        }

        public IEnumerable<AdressDal> GetAll()
        {
            Command command = new Command(@"SELECT Adress.Id, street, number, City.name as city, postCode, Country.name as country From Adress
                                            JOIN City ON City.Id = Adress.city_Id
                                            JOIN Country ON Country.Id = City.country_Id", false);
            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToAdressDal());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public AdressDal GetById(int id)
        {
            Command command = new Command(
            @"SELECT Adress.Id, street, number, City.name as city, postCode, Country.name as country From Adress
                JOIN City ON City.Id = Adress.city_Id
                JOIN Country ON Country.Id = City.country_Id
                WHERE Adress.Id = @id", false);
            command.AddParameter("id", id);

            try
            {
                return _connection.ExecuteReader(command, dr => dr.ToAdressDal()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public AdressDal Insert(AdressFormDal form)
        {
            int countryId;
            Command command1 = new Command(@"INSERT INTO[Country](name) OUTPUT inserted.id VALUES(@country)", false);
            command1.AddParameter("country", form.Country);
            try
            {
                countryId = (int)_connection.ExecuteScalar(command1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            int cityId;
            Command command2 = new Command(@"INSERT INTO[City](name,postCode,country_Id) OUTPUT inserted.id VALUES(@city,@postCode,@countryId)", false);
            command2.AddParameter("city", form.City);
            command2.AddParameter("postCode", form.PostCode);
            command2.AddParameter("countryId", countryId);
            try
            {
                cityId = (int)_connection.ExecuteScalar(command2); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

            int adressId;
            Command command3 = new Command(@"INSERT INTO[Adress](street,number,city_Id) OUTPUT inserted.id VALUES(@street,@number,@cityId)", false);
            command3.AddParameter("street", form.Street);
            command3.AddParameter("number", form.PostCode);
            command3.AddParameter("cityId", cityId);
            try
            {
                adressId = (int)_connection.ExecuteScalar(command3);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            AdressDal adress = GetById(adressId);

            return adress;
        }

        public AdressDal Update(AdressFormDal form)
        {
            int cityId;
            Command command1 = new Command(@"UPDATE [Adress] SET street = @street, number = @number
                                            OUTPUT inserted.city_Id 
                                            WHERE Id=@Id;", false);
            command1.AddParameter("street", form.Street);
            command1.AddParameter("number", form.Number);
            command1.AddParameter("Id", form.Id);
            try
            {
                cityId = (int)_connection.ExecuteScalar(command1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            int countryId;
            Command command2 = new Command(@"UPDATE [City] SET name = @name, postCode = @postCode
                                            OUTPUT inserted.country_Id 
                                            WHERE Id=@Id;", false);
            command2.AddParameter("name", form.City);
            command2.AddParameter("postCode", form.PostCode);
            command2.AddParameter("Id", cityId);
            try
            {
                countryId = (int)_connection.ExecuteScalar(command2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
            Command command3 = new Command(@"UPDATE [Country] SET name = @name
                                            WHERE Id=@Id;", false);
            command3.AddParameter("name", form.Country);
            command3.AddParameter("Id", countryId);
            try
            {
                _connection.ExecuteScalar(command3);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            AdressDal adress = GetById(form.Id);

            return adress;
        }
    }
}
