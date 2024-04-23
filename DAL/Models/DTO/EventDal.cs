namespace DAL.Models.DTO
{
    public class EventDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DiveplaceId { get; set; }
        public int CreatorId { get; set; }
        public int TrainingId { get; set; }
        public int ClubId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
