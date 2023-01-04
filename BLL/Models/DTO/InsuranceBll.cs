﻿namespace BLL.Models.DTO
{
    public class InsuranceBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
