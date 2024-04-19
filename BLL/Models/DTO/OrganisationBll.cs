namespace BLL.Models.DTO
{
    public class OrganisationBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GuidImage { get; set; }
        public int AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public AdressBll? Adress { get; set; }

    
    }
}
