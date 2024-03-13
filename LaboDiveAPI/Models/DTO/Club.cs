using API.Models.DTO.UserAPI;
namespace API.Models.DTO
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public Adress? Adress { get; set; }
        public User? Creator { get; set; }
    }
}
