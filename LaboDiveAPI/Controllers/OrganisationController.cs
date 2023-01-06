
using API.Mappers;
using API.Models.Forms.Insurance;
using API.Models.Forms.Message;
using API.Models.Forms.Organisation;
using API.Tools;
using BLL.Interfaces;
using BLL.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationBll _organisationBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public OrganisationController(ILogger<OrganisationController> logger, ITokenManager token, IOrganisationBll organisationBll)
        {
            _organisationBll = organisationBll;
            _logger = logger;
            _token = token;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_organisationBll.GetAll().Select(u => u.ToOrganisation()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_organisationBll.GetById(id)?.ToOrganisation());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] AddOrganisationForm form)
        {


            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });


            try
            {
                return Ok(_organisationBll.Insert(form.ToAddOrganisationFromBll())?.ToOrganisation());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateOrganisationForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_organisationBll.Update(form.ToUpdateOrganisationFormBll())?.ToOrganisation());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la modification a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_organisationBll.Delete(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPatch("Enable/{id}")]
        public IActionResult Enable(int id)
        {
            try
            {
                return Ok(_organisationBll.Enable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPatch("Disable/{id}")]
        public IActionResult Disable(int id)
        {
            try
            {
                return Ok(_organisationBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Participe")]
        public IActionResult Participe([FromBody] AddOrganisationParticipeForm form)
        {

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                return Ok(_organisationBll.Participe(form.ToAddOrganisationParticipeFormBll()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpDelete("UnParticpe/{userId}/{organisationId}")]
        public IActionResult UnParticpe(int userId, int organisationId)
        {
            try
            {
                return Ok(_organisationBll.UnParticipe(userId, organisationId));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

    }
}
