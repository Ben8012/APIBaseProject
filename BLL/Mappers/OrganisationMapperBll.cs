using BLL.Models.DTO;
using BLL.Models.Forms.Organisation;
using DAL.Models.DTO;
using DAL.Models.Forms.Organisation;

namespace BLL.Mappers
{
    public static class OrganisationMapperBll
    {
        internal static OrganisationBll ToOrganisationBll(this OrganisationDal organisationDal)
        {
            return new OrganisationBll()
            {
                Id = organisationDal.Id,
                Name = organisationDal.Name,
                Picture = organisationDal.Picture,
                CreatedAt = organisationDal.CreatedAt,
                UpdatedAt = organisationDal.UpdatedAt,
                IsActive = organisationDal.IsActive,
                AdressId = organisationDal.AdressId,

            };
        }

        internal static AddOrganisationFormDal ToAddOrganisationFromDal(this AddOrganisationFormBll addOrganisationFromBll)
        {
            return new AddOrganisationFormDal()
            {
                Name = addOrganisationFromBll.Name,
                Picture = addOrganisationFromBll.Picture,
                AdressId = addOrganisationFromBll.AdressId,
            };
        }

        internal static UpdateOrganisationFormDal ToUpdateOrganisationFormDal(this UpdateOrganisationFormBll updateOrganisationFormBll)
        {
            return new UpdateOrganisationFormDal()
            {
                Id = updateOrganisationFormBll.Id,
                Name = updateOrganisationFormBll.Name,
                Picture = updateOrganisationFormBll.Picture,
                AdressId = updateOrganisationFormBll.AdressId,
            };
        }
    }
}
