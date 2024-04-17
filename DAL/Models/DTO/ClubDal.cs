﻿namespace DAL.Models.DTO
{
    public class ClubDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public int AdressId { get; set; }
        public int CreatorId { get; set; }
        
    }
}
