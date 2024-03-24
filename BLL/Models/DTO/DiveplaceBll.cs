﻿namespace BLL.Models.DTO
{
    public class DiveplaceBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Map { get; set; }
        public string? Description { get; set; }
        public int AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public AdressBll? Adress { get; set; }
        public string Gps { get; set; }
        public int MaxDepp { get; set; }
        public int Price { get; set; }
        public bool Compressor { get; set; }
        public bool Restoration { get; set; }

        public int AvgVote { get; set;}

        public string Url { get; set; }

        public int UserVote { get; set; }

    }
}
