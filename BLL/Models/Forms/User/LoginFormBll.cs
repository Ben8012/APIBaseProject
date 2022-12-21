using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Forms
{
    public class LoginFormBll
    {
        [Required]
        [EmailAddress]
        [MinLength(1)]
        [MaxLength(384)]
        public string Email { get; set; }
      

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
