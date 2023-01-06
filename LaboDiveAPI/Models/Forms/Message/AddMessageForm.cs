using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Message
{
    public class AddMessageForm
    {
        [Required]
        public int SenderId { get; set; }

        [Required]
        public int RecieverId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
