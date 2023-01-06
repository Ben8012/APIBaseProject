using API.Models.DTO;
using API.Models.Forms.Message;
using API.Models.Forms.Organisation;
using BLL.Models.DTO;
using BLL.Models.Forms.Message;
using BLL.Models.Forms.Organisation;

namespace API.Mappers
{
    public static class OrganisationMapperAPI
    {
        internal static Organisation ToOrganisation(this OrganisationBll organisationBll)
        {
            return new Organisation()
            {
                Id = organisationBll.Id,
                Name= organisationBll.Name,
                Picture= organisationBll.Picture,
                CreatedAt= organisationBll.CreatedAt,
                UpdatedAt= organisationBll.UpdatedAt,
                IsActive= organisationBll.IsActive,
                AdressId = organisationBll.AdressId,

            };
        }

        internal static AddOrganisationFormBll ToAddOrganisationFromBll(this AddOrganisationForm addOrganisationFrom)
        {
            return new AddOrganisationFormBll()
            {
                Name = addOrganisationFrom.Name,
                Picture = addOrganisationFrom.Picture,
                AdressId = addOrganisationFrom.AdressId,
            };
        }

        internal static UpdateOrganisationFormBll ToUpdateOrganisationFormBll(this UpdateOrganisationForm updateOrganisationForm)
        {
            return new UpdateOrganisationFormBll()
            {
                Id = updateOrganisationForm.Id,
                Name = updateOrganisationForm.Name,
                Picture = updateOrganisationForm.Picture,
                AdressId = updateOrganisationForm.AdressId,
            };
        }

        internal static AddOrganisationParticipeFormBll ToAddOrganisationParticipeFormBll(this AddOrganisationParticipeForm form)
        {
            return new AddOrganisationParticipeFormBll()
            {
                UserId = form.UserId,
                OrganisationId = form.OrganisationId,
                Level = form.Level,
                RefNumber = form.RefNumber,
            };
        }
    }
}
