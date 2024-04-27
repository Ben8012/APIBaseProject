using API.Models.Forms.Adress;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Forms.Organisation
{
    public class AddOrganisationForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public AdressForm Adress { get; set; }
    }
}
