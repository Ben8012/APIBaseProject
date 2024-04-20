using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Divelog
{
    public class UpdateDivelogForm
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int MaxDeep { get; set; }

        public int AirTemperature { get; set; }

        public int WaterTemperature { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
