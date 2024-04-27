using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Message;
using BLL.Models.Forms.Organisation;
using DAL.Interfaces;
using DAL.Models.DTO;
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
        private readonly IUserBll _userBll;
        private readonly IAdressBll _adressBll;

        public OrganisationBllService(ILogger<OrganisationBllService> logger, IOrganisationDal organisationDal, IUserBll userBll, IAdressBll adressBll)
        {
            _organisationDal = organisationDal;
            _logger = logger;
            _userBll = userBll;
            _adressBll = adressBll;
        }

        public IEnumerable<OrganisationBll> Delete(int id)
        {
            int? nbligne = _organisationDal.Delete(id);
            List<OrganisationBll> organisations = new List<OrganisationBll>();
            if (nbligne.HasValue)
            {
                organisations = _organisationDal.GetAll().Select(u => u.ToOrganisationBll()).ToList();
            }
            return organisations;
        }

        public IEnumerable<OrganisationBll> GetAll()
        {
            List<OrganisationBll> organisations = _organisationDal.GetAll().Select(u => u.ToOrganisationBll()).ToList();
            foreach (var organisation in organisations)
            {
                organisation.Adress = organisation.AdressId == 0 ? null : _adressBll.GetById(organisation.AdressId);
            }
            return organisations;
        }

        public OrganisationBll? GetById(int id)
        {
            OrganisationBll organisation = _organisationDal.GetById(id)?.ToOrganisationBll();
            organisation.Adress = organisation.AdressId == 0 ? null : _adressBll.GetById(organisation.AdressId);
            return organisation;
        }

        public OrganisationBll? Insert(AddOrganisationFormBll form)
        {
       
            AdressBll adress = _adressBll.Insert(form.Adress);
            form.AdressId = adress.Id;
            OrganisationBll organisation = _organisationDal.Insert(form.ToAddOrganisationFromDal())?.ToOrganisationBll();
            return organisation;
        }

        public OrganisationBll? Update(UpdateOrganisationFormBll form)
        {

            AdressBll adress = _adressBll.Insert(form.Adress);
            form.AdressId = adress.Id;
            OrganisationBll organisation = _organisationDal.Update(form.ToUpdateOrganisationFormDal())?.ToOrganisationBll();
            return organisation;
          
        }

        public int? Disable(int id)
        {
            return _organisationDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _organisationDal.Enable(id); ;
        }
    }
}
