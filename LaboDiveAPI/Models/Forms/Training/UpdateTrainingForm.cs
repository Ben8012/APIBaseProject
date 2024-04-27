using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Training
{
    public class UpdateTrainingForm
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }


        public int PrerequisId { get; set; }


        [Required]
        public bool IsSpeciality { get; set; }

        [Required]
        public int OrganisationId { get; set; }

        public string Description { get; set; }
    }
}
