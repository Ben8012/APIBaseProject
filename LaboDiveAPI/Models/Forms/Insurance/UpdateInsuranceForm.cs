using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Insurance
{
    public class UpdateInsuranceForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Picture { get; set; }

        [Required]
        public int AdressId { get; set; }
    }
}
