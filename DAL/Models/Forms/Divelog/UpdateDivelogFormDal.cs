﻿namespace DAL.Models.Forms.Divelog
{
    public class UpdateDivelogFormDal
    {
        public int Id { get; set; }
        public string DiveType { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int MaxDeep { get; set; }
        public int AirTemperature { get; set; }
        public int WaterTemperature { get; set; }
        public DateTime DiveDate { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
