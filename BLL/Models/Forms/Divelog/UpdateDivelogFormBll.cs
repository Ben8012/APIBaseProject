namespace BLL.Models.Forms.Divelog
{
    public class UpdateDivelogFormBll
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int MaxDeep { get; set; }
        public int AirTemperature { get; set; }
        public int WaterTemperature { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
