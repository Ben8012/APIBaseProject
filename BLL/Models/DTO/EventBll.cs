namespace BLL.Models.DTO
{
    public class EventBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DiveplaceId { get; set; }
        public int CreatorId { get; set; }
        public int TrainingId { get; set; }
        public int ClubId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public UserBll? Creator { get; set; }
        public TrainingBll? Training { get; set; }
        public ClubBll? Club { get; set; }
        public DiveplaceBll Diveplace { get; set; }
    }
}
