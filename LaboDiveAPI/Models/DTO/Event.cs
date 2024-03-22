using API.Models.DTO.UserAPI;
using BLL.Models.DTO;

namespace API.Models.DTO
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User? Creator { get; set; }
        public Training? Training { get; set; }
        public Club? Club { get; set; }
        public Diveplace? Diveplace { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public List<User>? Participes { get; set; }
    }
}
