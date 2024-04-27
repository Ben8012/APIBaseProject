using BLL.Models.Forms.Adress;

namespace BLL.Models.Forms.Organisation
{
    public class AddOrganisationFormBll
    {
        public string Name { get; set; }
        public AdressFormBll Adress { get; set; }

        public int AdressId { get; set; }

    }
}
