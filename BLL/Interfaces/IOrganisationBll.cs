using BLL.Models.DTO;
using BLL.Models.Forms.Message;
using BLL.Models.Forms.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrganisationBll
    {
        IEnumerable<OrganisationBll> GetAll();

        OrganisationBll? GetById(int id);

        OrganisationBll? Insert(AddOrganisationFormBll form);

        OrganisationBll? Update(UpdateOrganisationFormBll form);

        IEnumerable<OrganisationBll> Delete(int id);
        int? Enable(int id);

        int? Disable(int id);

        //int? Participe(AddOrganisationParticipeFormBll form);
        //int? UnParticipe(int userId, int organisationId);
    }
}
