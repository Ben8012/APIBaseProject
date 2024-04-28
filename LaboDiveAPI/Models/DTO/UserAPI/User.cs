using BLL.Models.DTO;

namespace API.Models.DTO.UserAPI
{
    public class User
    {
        public int Id { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string GuidImage { get; set; }
        public string GuidInsurance { get; set; }
        public string GuidLevel { get; set; }
        public string GuidCertificat { get; set; }
        public bool IsLevelValid { get; set; }
        public DateTime? MedicalDateValidation { get; set; }
        public DateTime? InsuranceDateValidation { get; set; }
        public string Token { get; set; }

        public Adress? Adress { get; set; }

        public List<Training>? Trainings { get; set;}

        public List<Divelog>? Divelogs { get; set; }

        public List<Diveplace>? Diveplaces { get; set;}

        public List<User>? Friends { get; set; }
        public List<User>? Likers { get; set; }
        public List<User>? Likeds { get; set; }

        public List<Club>? Clubs { get;set; }

        public List<Event>? Events { get; set; }
        public List<Message>? Messages { get; set; }


    }
}
