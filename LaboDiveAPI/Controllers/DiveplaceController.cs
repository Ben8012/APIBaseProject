using API.Mappers;
using API.Models.Forms.Divelog;
using API.Models.Forms.Diveplace;
using API.Models.Forms.Insurance;
using API.Tools;
using BLL.Interfaces;
using BLL.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiveplaceController : ControllerBase
    {

        private readonly IDiveplaceBll _diveplaceBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public DiveplaceController(ILogger<DiveplaceController> logger, ITokenManager token, IDiveplaceBll diveplaceBll)
        {
            _diveplaceBll = diveplaceBll;
            _logger = logger;
            _token = token;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Ok(_diveplaceBll.GetAll().Select(u => u.ToDiveplace()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpGet("GetAllSiteAndVote/{userId}")]
        public IActionResult GetAllSiteAndVote(int userId)
        {
            try
            {
                return Ok(_diveplaceBll.GetAllSiteAndVote(userId).Select(u => u.ToDiveplace()));
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
                return Ok(_diveplaceBll.GetById(id)?.ToDiveplace());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] DiveplaceForm form)
        {


            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });


            try
            {
                return Ok(_diveplaceBll.Insert(form.ToDiveplaceFormBll())?.ToDiveplace());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut]
        public IActionResult Update([FromBody] DiveplaceForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_diveplaceBll.Update(form.ToDiveplaceFormBll())?.ToDiveplace());
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
                return Ok(_diveplaceBll.Delete(id));

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
                return Ok(_diveplaceBll.Enable(id));

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
                return Ok(_diveplaceBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Vote")]
        public IActionResult Vote([FromBody] AddDiveplaceVoteForm form)
        {
            try
            {
                int userId = form.UserId;
                int diveplaceId = form.DiveplaceId;
                int vote = form.Evalutation;
                return Ok(_diveplaceBll.Vote(userId, diveplaceId, vote));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

    }
}
