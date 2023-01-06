using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Diveplace
{
    public class AddDiveplaceVoteForm
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int DiveplaceId { get; set; }

        [Required]
        public int Evalutation { get; set; }
    }
}
