using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Forms
{
    public class LoginFormDal
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
