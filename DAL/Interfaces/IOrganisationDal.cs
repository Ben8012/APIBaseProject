using DAL.Models.DTO;
using DAL.Models.Forms.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrganisationDal
    {
        IEnumerable<OrganisationDal> GetAll();
        OrganisationDal? GetById(int id);
        OrganisationDal? Insert(AddOrganisationFormDal form);
        OrganisationDal? Update(UpdateOrganisationFormDal form);

        int? Delete(int id);
        int? Enable(int id);
        int? Disable(int id);
        int? Participe(AddOrganisationParticipeFormDal form);
        int? UnParticipe(int userId, int organisationId);
    }
}
