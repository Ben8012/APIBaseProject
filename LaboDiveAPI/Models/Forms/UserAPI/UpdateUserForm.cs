using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.UserAPI
{
    public class UpdateUserForm
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

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? InsuranceNumber { get; set; }

        public int? InsuranceId { get; set; }

        public string? Phone { get; set; }

        [Required]
        public int AdressId { get; set; }
    }
}
