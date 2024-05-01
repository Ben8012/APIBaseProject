using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.UserAPI
{
    public class ResetPassword
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [EmailAddress]
        [MinLength(3)]
        [MaxLength(384)]
        public string Email { get; set; }
    }
}
