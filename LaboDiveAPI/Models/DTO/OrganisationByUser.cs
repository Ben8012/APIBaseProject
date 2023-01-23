﻿namespace API.Models.DTO
{
    public class OrganisationByUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string RefNunber { get; set; }
        public string Picture { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
