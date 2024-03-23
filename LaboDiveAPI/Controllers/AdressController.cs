using API.Mappers;
using API.Models.DTO.UserAPI;
using API.Models.Forms.Adress;
using API.Models.Forms.UserAPI;
using BLL.Interfaces;
using BLL.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize("Auth")]
    public class AdressController : ControllerBase
    {
        private readonly IAdressBll _adressBll;

        public AdressController(IAdressBll adressBll)
        {
            _adressBll= adressBll;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_adressBll.GetAll().Select(u => u.ToAdress()));
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
                return Ok(_adressBll.GetById(id)?.ToAdress());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Insert([FromBody] AdressForm form)
        {
  
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                return Ok(_adressBll.Insert(form.ToAdressBll()).ToAdress());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AdressForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_adressBll.Update(form.ToAdressBll()).ToAdress());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la modification a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        return Ok(_adressBll.Delete(id));

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
        //    }
        //}
    }
}
