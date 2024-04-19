using BLL.Models.DTO;

namespace API.Models.DTO
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Picture { get; set; }
        public bool IsSpeciality { get; set; }
        public Organisation? Organisation { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string Description { get; set; }

        public string? RefNumber { get; set; }
        public bool? IsMostLevel { get; set; }
    }
}
