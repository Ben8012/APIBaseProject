using API.Mappers;
using API.Models.DTO;
using API.Models.DTO.UserAPI;
using API.Models.Forms.Club;
using API.Models.Forms.Insurance;
using API.Tools;
using BLL.Interfaces;
using BLL.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Auth")]
    public class ClubController : ControllerBase
    {
        private readonly IClubBll _clubBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public ClubController(ILogger<ClubController> logger, ITokenManager token, IClubBll clubBll)
        {
            _clubBll= clubBll;
            _logger = logger;
            _token = token;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_clubBll.GetAll().Select(u => u.ToClub()));
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
                return Ok(_clubBll.GetById(id)?.ToClub());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetClubByUserId/{id}")]
        public IActionResult GetClubByUserId(int id)
        {
            try
            {
                return Ok(_clubBll.GetClubsByUserId(id).Select(c => c.ToClub()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] ClubForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                return Ok(_clubBll.Insert(form.ToClubFormBll())?.ToClub());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] ClubForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_clubBll.Update(form.ToClubFormBll())?.ToClub());
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
                return Ok(_clubBll.Delete(id));

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
                return Ok(_clubBll.Enable(id));

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
                return Ok(_clubBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Participate/{userId}/{clubId}")]
        public IActionResult Participate(int userId, int clubId)
        {

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                return Ok(_clubBll.Participate(userId, clubId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpGet("UnParticipate/{userId}/{clubId}")]
        public IActionResult UnParticipate(int userId, int clubId)
        {
            try
            {
                return Ok(_clubBll.UnParticipate( userId,  clubId));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpGet("ValidationParticipate/{userId}/{clubId}")]
        public IActionResult ValidationParticipate(int userId, int clubId)
        {
            try
            {
                int? ligne = _clubBll.ValidationParticipate(userId, clubId);
                List<Club> clubs = new List<Club>();
                if (ligne.HasValue)
                {
                    clubs = _clubBll.GetClubsByUserId(userId).Select(u => u.ToClub()).ToList();
                }
                return Ok(clubs);

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("UnValidationParticipate/{userId}/{clubId}")]
        public IActionResult UnValidationParticipate(int userId, int clubId)
        {
            try
            {
                int? ligne = _clubBll.UnValidationParticipate(userId, clubId);
                List<Club> clubs = new List<Club>();
                if (ligne.HasValue)
                {
                    clubs = _clubBll.GetClubsByUserId(userId).Select(u => u.ToClub()).ToList();
                }
                return Ok(clubs);

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

 

    }
}
