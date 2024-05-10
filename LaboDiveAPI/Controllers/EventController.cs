using API.Mappers;
using API.Models.DTO;
using API.Models.Forms.Event;
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventBll _eventBll;
        private readonly IEventDal _eventDal;
        private readonly ITrainingBll _trainingBll;
        public EventController(IEventBll eventBll, IEventDal eventDal, ITrainingBll trainingBll)
        {
            _eventBll = eventBll;
            _eventDal = eventDal;
            _trainingBll = trainingBll;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Event>events = _eventBll.GetAll().Select(u => u.ToEvent()).ToList();

                //List<EventBll> events = _eventDal.GetAll().Select(u => u.ToEventBll()).ToList();
                return Ok(events);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return StatusCode(500, new { Message = "Failed to retrieve events. Please contact the administrator." });
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

        [HttpGet("GetEventByUserId/{id}")]
        public IActionResult GetEventByUserId(int id)
        {
            try
            {
                return Ok(_eventBll.GetEventByUserId(id).Select(u => u.ToEvent()));
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

        [HttpGet("Participate/{userId}/{eventId}")]
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

        [HttpGet("UnParticipate/{userId}/{eventId}")]
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



        [HttpGet("ValidationParticipate/{userId}/{eventId}")]
        public IActionResult ValidationParticipate(int userId, int eventId)
        {

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                int? ligne = _eventBll.ValidationParticipate(userId, eventId);
                List<Event> events = new List<Event>();
                if (ligne.HasValue)
                {
                    events = _eventBll.GetEventByUserId(userId).Select(e => e.ToEvent()).ToList();
                }
                
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpGet("UnValidationParticipate/{userId}/{eventId}")]
        public IActionResult UnValidationParticipate(int userId, int eventId)
        {
            try
            {
                int? ligne = _eventBll.UnValidationParticipate(userId, eventId);
                List<Event> events = new List<Event>();
                if (ligne.HasValue)
                {
                    events = _eventBll.GetEventByUserId(userId).Select(e => e.ToEvent()).ToList();
                }
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetAllParticipeByEventId/{eventId}")]
        public IActionResult GetAllParticipeByEventId(int id)
        {
            try
            {
                return Ok( _eventBll.GetAllParticipeByEventId(id).Select(u => u.ToUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetAllDemandsByEventId/{eventId}")]
        public IActionResult GetAllDemandsByEventId(int id)
        {
            try
            {
                return Ok(_eventBll.GetAllDemandsByEventId(id).Select(u => u.ToUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }
       
    }
}
