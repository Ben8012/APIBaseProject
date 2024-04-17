using API.Models.DTO.UserAPI;
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
        public Adress? Adress { get; set; }
        public User? Creator { get; set; }

        public List<User>? Participes { get; set; }
       
        public List<User>? Demands { get; set; }
    }
}
