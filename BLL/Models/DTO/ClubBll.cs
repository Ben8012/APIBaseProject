namespace BLL.Models.DTO
{
    public class ClubBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public int AdressId { get; set; }
        public int CreatorId { get; set; }
        public UserBll? Creator { get; set; }
        public AdressBll? Adress { get; set; }

        public List<UserBll>? Participes { get; set; }
    }
}
