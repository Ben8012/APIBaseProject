namespace API.Models.DTO
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Picture { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
