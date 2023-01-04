using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.UserAPI
{
    public class UpdateUserForm
    {

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string? InsuranceNumber { get; set; }
        public int? InsuranceId { get; set; }
        public string? Phone { get; set; }
        public int AdressId { get; set; }
    }
}
