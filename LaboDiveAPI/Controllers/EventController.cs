using API.Mappers;
using API.Models.Forms.Diveplace;
using API.Models.Forms.Event;
using API.Models.Forms.Insurance;
using API.Tools;
using BLL.Interfaces;
using BLL.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventBll _eventBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public EventController(ILogger<EventController> logger, ITokenManager token, IEventBll eventBll)
        {
            _eventBll = eventBll;
            _logger = logger;
            _token = token;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_eventBll.GetAll().Select(u => u.ToEvent()));
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
                return Ok(_eventBll.GetById(id)?.ToEvent());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] AddEventForm form)
        {


            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });


            try
            {
                return Ok(_eventBll.Insert(form.ToAddEventFromBll())?.ToEvent());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateEventForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_eventBll.Update(form.ToUpdateEventFormBll())?.ToEvent());
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
                return Ok(_eventBll.Delete(id));

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
                return Ok(_eventBll.Enable(id));

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
                return Ok(_eventBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Participate/{userId}/{eventId}")]
        public IActionResult Participate(int userId, int eventId)
        {

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                return Ok(_eventBll.Participate(userId, eventId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpDelete("UnParticipate/{userId}/{eventId}")]
        public IActionResult UnParticipate(int userId, int eventId)
        {
            try
            {
                return Ok(_eventBll.UnParticipate(userId, eventId));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Invite/{inviterId}/{invitedId}/{eventId}")]
        public IActionResult Invite(int inviterId,int invitedId, int eventId)
        {

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                return Ok(_eventBll.Invite(inviterId, invitedId, eventId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpDelete("UnInvite/{inviterId}/{invitedId}/{eventId}")]
        public IActionResult UnInvite(int inviterId, int invitedId, int eventId)
        {
            try
            {
                return Ok(_eventBll.UnInvite(inviterId, invitedId, eventId));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }




    }
}
