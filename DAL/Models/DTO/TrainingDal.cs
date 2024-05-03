using System.Security.Cryptography;

namespace DAL.Models.DTO
{
    public class TrainingDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrerequisId { get; set; }
        public byte[]? GuidImage { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string Description { get; set; }

        public string? RefNumber { get; set; }

        public bool? IsMostLevel { get; set; }

      
    }
}
