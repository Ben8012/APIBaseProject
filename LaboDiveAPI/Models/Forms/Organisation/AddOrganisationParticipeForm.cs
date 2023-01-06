using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Organisation
{
    public class AddOrganisationParticipeForm
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int OrganisationId { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Level { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string RefNumber { get; set; }
    }
}
