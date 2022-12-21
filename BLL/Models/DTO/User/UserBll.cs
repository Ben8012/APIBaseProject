namespace BLL.Models.DTO.User
{
    public class UserBll
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
