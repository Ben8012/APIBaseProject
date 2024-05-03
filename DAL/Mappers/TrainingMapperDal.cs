using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class TrainingMapperDal
    {
        internal static TrainingDal ToTrainingDal(this DbDataReader reader)
        {
            return new TrainingDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                PrerequisId = reader["prerequis_Id"] is DBNull ? 0 : (int)reader["prerequis_Id"],
                GuidImage = reader["guidImage"] is DBNull ? null : (byte[])reader["guidImage"],
                IsSpeciality = (bool)reader["isSpeciality"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                OrganisationId = (int)reader["organisation_Id"],
                Description = reader["Description"] is DBNull ? "" : (string)reader["Description"],
            };

        }

      
    internal static TrainingDal ToTrainingByUserDal(this DbDataReader reader)
        {
            return new TrainingDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                PrerequisId = reader["prerequis_Id"] is DBNull ? 0 : (int)reader["prerequis_Id"],
                GuidImage = reader["guidImage"] is DBNull ? null : (byte[])reader["guidImage"],
                IsSpeciality = (bool)reader["isSpeciality"],
                CreatedAt = (DateTime)reader["createdAt"],
                UpdatedAt = reader["updatedAt"] is DBNull ? null : (DateTime?)reader["updatedAt"],
                IsActive = (bool)reader["isActive"],
                OrganisationId = (int)reader["organisation_Id"],
                Description = reader["description"] is DBNull ? "" : (string)reader["description"],
                RefNumber = reader["refNumber"] is DBNull ? "" : (string)reader["refNumber"],
                IsMostLevel = (bool)reader["isMostLevel"],
            };

        }
    }
}
