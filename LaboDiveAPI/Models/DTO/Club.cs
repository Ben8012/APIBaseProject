using BLL.Models.DTO;

namespace API.Models.DTO
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public AdressBll? Adress { get; set; }
        public int CreatorId { get; set; }
    }
}
