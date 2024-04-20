using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Divelog
{
    public class AddDivelogForm
    {
     
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int MaxDeep { get; set; }

        public int AirTemperature { get; set; }

        [Required]
        public int WaterTemperature { get; set; }


        [Required]
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
