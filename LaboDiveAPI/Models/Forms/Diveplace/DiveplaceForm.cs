
using API.Models.Forms.Adress;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Diveplace
{
    public class DiveplaceForm
    {
        public int? Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public AdressForm Adress { get; set; }

        [Required]
        public bool Compressor { get; set; }

        [Required]
        public bool Restoration { get; set; }

        public string? Gps { get; set; }
        public string? Url { get; set; }

        [Required]
        public int MaxDeep { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CreatorId { get; set; }





    }
}
