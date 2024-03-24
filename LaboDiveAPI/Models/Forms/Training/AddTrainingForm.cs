using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Training
{
    public class AddTrainingForm
    {

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Prerequisite { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Picture { get; set; }

        [Required]
        public bool IsSpeciality { get; set; }

        [Required]
        public int OrganisationId { get; set; }

        public string Description { get; set; }
    }
}
