using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Forms
{
    public class UpdateUserFormBll
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(1)]
        [MaxLength(384)]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
