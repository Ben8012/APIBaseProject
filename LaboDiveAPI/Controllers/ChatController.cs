using API.Mappers;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Auth")]
    public class ChatController : Controller
    {
        private readonly IMessageBll _messageBll;
        public ChatController(IMessageBll messageBll)
        {
           _messageBll= messageBll;
        }

        [HttpGet("{sender}/{reciever}")]
        public IActionResult GetMessage(int sender, int reciever)
        {
            return Ok(_messageBll.GetMessagesBetween(sender, reciever).Select(m => m.ToMessage()));
        }
    }
}
