using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Message;
using BLL.Models.Forms.Organisation;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrganisationBllService : IOrganisationBll
    {

        private readonly ILogger _logger;
        private readonly IOrganisationDal _organisationDal;

        public OrganisationBllService(ILogger<OrganisationBllService> logger, IOrganisationDal organisationDal)
        {
            _organisationDal = organisationDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _organisationDal.Delete(id);
        }

        public IEnumerable<OrganisationBll> GetAll()
        {
            return _organisationDal.GetAll().Select(u => u.ToOrganisationBll());
        }

        public OrganisationBll? GetById(int id)
        {
            return _organisationDal.GetById(id)?.ToOrganisationBll();
        }

        public OrganisationBll? Insert(AddOrganisationFormBll form)
        {
            return _organisationDal.Insert(form.ToAddOrganisationFromDal())?.ToOrganisationBll();
        }

        public OrganisationBll? Update(UpdateOrganisationFormBll form)
        {
            return _organisationDal.Update(form.ToUpdateOrganisationFormDal())?.ToOrganisationBll();
        }
    }
}
