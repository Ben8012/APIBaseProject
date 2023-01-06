using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Diveplace
{
    public class AddDiveplaceForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Picture { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Map { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string AdressId { get; set; }
    }
}
