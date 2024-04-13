
using DAL.Models.Forms.Adress;

namespace DAL.Models.Forms.Diveplace
{
    public class DiveplaceFormDal
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Compressor { get; set; }
        public bool Restoration { get; set; }
        public string? Gps { get; set; }
        public string? Url { get; set; }
        public int MaxDeep { get; set; }
        public double Price { get; set; }

        public int CreatorId { get; set; }
        public int? AdressId { get; set; }
    }
}
