using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Training
{
    public class UserTrainingForm
    {
        public int? Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TrainingId { get; set; }
        public bool? IsMostlevel { get; set; }
        public string RefNumber { get; set; }
    }
}
