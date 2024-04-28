using API.Models.DTO.UserAPI;
using BLL.Models.DTO;

namespace API.Models.DTO
{
    public class Message
    {
        public int Id { get; set; }
        public User? Sender { get; set; }
        public User? Reciever { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public bool IsRead { get; set; }
    }
}
