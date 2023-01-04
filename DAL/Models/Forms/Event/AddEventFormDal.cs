
namespace DAL.Models.Forms.Event
{
    public class AddEventFormDal
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DiveplaceId { get; set; }
        public int CreatorId { get; set; }
        public int TrainingId { get; set; }
        public int ClubId { get; set; }
    }
}
