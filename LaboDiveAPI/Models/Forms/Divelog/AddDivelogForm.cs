using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Divelog
{
    public class AddDivelogForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string DiveType { get; set; }
        
        [MinLength(1)]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int MaxDeep { get; set; }

        [Required]
        public int AirTemperature { get; set; }

        [Required]
        public int WaterTemperature { get; set; }

        [Required]
        public DateTime DiveDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
