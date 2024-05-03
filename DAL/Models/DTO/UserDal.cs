namespace DAL.Models.DTO
{
    public class UserDal
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public int AdressId { get; set; }

        public byte[]? GuidImage { get; set; }
        public byte[]? GuidInsurance { get; set; }
        public byte[]? GuidLevel { get; set; }
        public byte[]? GuidCertificat { get; set; }

        public bool IsLevelValid { get; set; }

        public DateTime? MedicalDateValidation { get; set; }
        public DateTime? InsuranceDateValidation { get; set; }


    }
}
