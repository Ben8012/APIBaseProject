using BLL.Models.DTO;
using BLL.Models.Forms.Adress;

namespace BLL.Models.Forms.Club
{
    public class ClubFormBll
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? AdressId { get; set; }
        public AdressFormBll? Adress { get; set; }
        public int CreatorId { get; set; }
    }
}
