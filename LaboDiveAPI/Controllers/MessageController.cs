using API.Mappers;
using API.Models.DTO;
using API.Models.Forms.Insurance;
using API.Models.Forms.Message;
using API.Tools;
using BLL.Interfaces;
using BLL.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageBll _messageBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public MessageController(ILogger<MessageController> logger, ITokenManager token, IMessageBll messageBll)
        {
            _messageBll = messageBll;
            _logger = logger;
            _token = token;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_messageBll.GetAll().Select(u => u.ToMessage()));
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
                return Ok(_messageBll.GetById(id)?.ToMessage());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] AddMessageForm form)
        {


            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });


            try
            {
                return Ok(_messageBll.Insert(form.ToAddMessageFromBll())?.ToMessage());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateMessageForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_messageBll.Update(form.ToUpdateMessageFormBll())?.ToMessage());
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
                return Ok(_messageBll.Delete(id));

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
                return Ok(_messageBll.Enable(id));

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
                return Ok(_messageBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("SenderMessages/{id}")]
        public IActionResult GetMessagesBySenderId(int id)
        {
            try
            {
                return Ok(_messageBll.GetMessagesBySenderId(id).Select(u => u.ToMessage()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("RecieverMessages{id}")]
        public IActionResult GetMessagesByRecieverId(int id)
        {
            try
            {
                return Ok(_messageBll.GetMessagesByRecieverId(id).Select(u => u.ToMessage()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

    }
}
