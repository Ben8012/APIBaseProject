using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Forms
{
    public class AddUserFormBll
    {
    
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
   
    }
}
