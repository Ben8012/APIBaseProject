using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Forms.Organisation
{
    public class AddOrganisationParticipeFormDal
    {
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public string Level { get; set; }
        public string RefNumber { get; set; }
    }
}
