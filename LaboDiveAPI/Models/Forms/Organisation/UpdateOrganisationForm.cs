using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Organisation
{
    public class UpdateOrganisationForm
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string GuidImage { get; set; }

        [Required]
        public int AdressId { get; set; }
    }
}
