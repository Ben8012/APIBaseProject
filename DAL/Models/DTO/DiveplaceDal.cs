﻿namespace DAL.Models.DTO
{
    public class DiveplaceDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? GuidImage { get; set; }
        public string? GuidMap { get; set; }
        public string? Description { get; set; }
        public int AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public int Evaluation { get; set; }
        public string? Gps { get; set; }
        public string? Url { get; set; }
        public int MaxDepp { get; set; }
        public double Price { get; set; }
        public bool Compressor { get; set; }
        public bool Restoration { get; set; }

        public int CreatorId { get; set; }

    }
}
