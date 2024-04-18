using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Forms
{
    public class AddUserFormDal
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string? InsuranceNumber { get; set; }
        public int? InsuranceId { get; set; }
        public int AdressId { get; set; }
    }
}
