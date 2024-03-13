﻿using BLL.Models.DTO;

namespace API.Models.DTO
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public Adress? Adress { get; set; }

        public string RefNumber { get; set; }
        public string Level { get; set; }
    }
}
