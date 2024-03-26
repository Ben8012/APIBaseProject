using Microsoft.Extensions.Logging;

namespace BLL.Models.DTO
{
    public class UserBll
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

        public int InsuranceId { get; set; }
        public int AdressId { get; set; }
        public string GuidImage { get; set; }
        public string GuidInsurance { get; set; }
        public string GuidLevel { get; set; }
        public string GuidCertificat { get; set; }
        public bool IsLevelValid { get; set; }
        public DateTime? MedicalDateValidation { get; set; }
        public DateTime? InsuranceDateValidation { get; set; }

        public AdressBll? Adress { get; set; }
        public List<OrganisationBll>? Organisations { get; set; }
        public InsuranceBll? Insurance { get; set; }
        public List<DivelogBll>? Divelogs { get; set; }
        public List<DiveplaceBll>? Diveplaces { get; set; }
        public List<UserBll>? Friends { get; set; }
        public List<ClubBll>? Clubs { get; set; }
        public List<EventBll>? Events { get; set; }

    }
}
