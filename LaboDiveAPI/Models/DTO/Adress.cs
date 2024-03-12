namespace API.Models.DTO
{
    public class Adress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
     
    }
}
