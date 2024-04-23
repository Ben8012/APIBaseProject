
using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Event
{
    public class AddEventForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int DiveplaceId { get; set; }

        [Required]
        public int CreatorId { get; set; }

        public int TrainingId { get; set; }
        public int ClubId { get; set; }
    }
}
