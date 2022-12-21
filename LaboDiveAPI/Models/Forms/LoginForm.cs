using System.ComponentModel.DataAnnotations;

namespace LaboDiveAPI.Models.Forms
{
    public class LoginForm
    {
        [Required(ErrorMessage = "l'email est requis")]
        [EmailAddress(ErrorMessage = "doit etre de format adresse email xx@xx.xx")]
        [MinLength(1, ErrorMessage = "longeur minimum de 1 charactere")]
        [MaxLength(384, ErrorMessage = "longeur maximum de 384 characteres")]
        public string Email { get; set; }


        [Required(ErrorMessage = "le mot de passe est requis")]
        [DataType(DataType.Password, ErrorMessage = "doit etre de type mot de passe")]
        public string Password { get; set; }
    }
}
