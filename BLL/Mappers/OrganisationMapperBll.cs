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
                Level = organisationDal.Level,
                RefNumber = organisationDal.RefNumber,

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

        internal static AddOrganisationParticipeFormDal ToAddOrganisationParticipeFormDal(this AddOrganisationParticipeFormBll form)
        {
            return new AddOrganisationParticipeFormDal()
            {
                UserId = form.UserId,
                OrganisationId = form.OrganisationId,
                Level = form.Level,
                RefNumber = form.RefNumber,
            };
        }
    }
}
