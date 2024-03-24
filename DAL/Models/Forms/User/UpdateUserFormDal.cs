using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Forms
{
    public class UpdateUserFormDal
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public byte[]? ProfilImage { get; set; }
    }
}
