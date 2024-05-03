using System.Security.Cryptography;

namespace BLL.Models.DTO
{
    public class TrainingBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrerequisiteId { get; set; }
        public byte[]? GuidImage { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public OrganisationBll? Organisation { get; set; }
        public TrainingBll? Prerequis { get; set; }

        public string Description { get; set; }

        public string? RefNumber { get; set; }
        public bool? IsMostLevel { get; set; }

        
    }
}
