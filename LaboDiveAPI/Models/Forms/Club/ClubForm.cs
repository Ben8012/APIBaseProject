using API.Models.Forms.Adress;
using BLL.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Club
{
    public class ClubForm
    {
        public int? Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public AdressForm? Adress { get; set; }

        [Required]
        public int CreatorId { get; set; }
    }
}
