﻿using DAL.Models.DTO;
using System.Data.Common;

namespace DAL.Mappers
{
    public static class EventMapperDal
    {
        internal static EventDal ToEventDal(this DbDataReader reader)
        {
            return new EventDal()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["name"],
                StartDate = (DateTime)reader["startDate"],
                EndDate = (DateTime)reader["endDate"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                UpdatedAt = reader["UpdatedAt"] is DBNull ? null : (DateTime?)reader["UpdatedAt"],
                IsActive = (bool)reader["isActive"],
                DiveplaceId = (int)reader["diveplace_id"],
                CreatorId = (int)reader["creator_id"],
                TrainingId = reader["training_Id"] is DBNull ?  0 : (int)reader["creator_id"],
                ClubId = reader["club_Id"] is DBNull ?  0 : (int)reader["club_id"],

            };

        }
    }
}
