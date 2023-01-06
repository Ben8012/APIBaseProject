using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Club
{
    public class AddClubForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int AdressId { get; set; }

        [Required]
        public int CreatorId { get; set; }
    }
}
