using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.Organisation
{
    public class AddOrganisationParticipeFormBll
    {
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public string Level { get; set; }
        public string RefNumber { get; set; }
    }
}
