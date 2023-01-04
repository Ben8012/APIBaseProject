namespace API.Models.Forms.Club
{
    public class UpdateClubForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdressId { get; set; }
        public int CreatorId { get; set; }
    }
}
