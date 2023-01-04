namespace DAL.Models.DTO
{
    public class OrganisationDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
