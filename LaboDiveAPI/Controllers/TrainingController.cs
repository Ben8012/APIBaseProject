using API.Mappers;
using API.Models.Forms.Insurance;
using API.Models.Forms.Organisation;
using API.Models.Forms.Training;
using API.Tools;
using BLL.Interfaces;
using BLL.Models.DTO;
using DAL.Models.DTO;
using DAL.Models.Forms.Training;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Auth")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingBll _trainingBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public TrainingController(ILogger<TrainingController> logger, ITokenManager token, ITrainingBll trainingBll)
        {
            _trainingBll = trainingBll;
            _logger = logger;
            _token = token;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_trainingBll.GetAll().Select(u => u.ToTraining()));
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
                return Ok(_trainingBll.GetById(id)?.ToTraining());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult Insert([FromBody] AddTrainingForm form)
        {


            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });


            try
            {
                return Ok(_trainingBll.Insert(form.ToAddTrainingFromBll())?.ToTraining());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut]
        public IActionResult Update([FromBody] UpdateTrainingForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_trainingBll.Update(form.ToUpdateTrainingFormBll())?.ToTraining());
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
                return Ok(_trainingBll.Delete(id).Select(u => u.ToTraining()));

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
                return Ok(_trainingBll.Enable(id));

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
                return Ok(_trainingBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetByOrganisationId/{id}")]
        public IActionResult GetByOrganisationId(int id)
        {
            try
            {
                return Ok(_trainingBll.GetTrainingsByOrganisationId(id)?.Select(u => u.ToTraining()).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("InsertUserTraining")]
        public IActionResult InsertUserTraining([FromBody] UserTrainingForm form)
        {
            try
            {
                return Ok(_trainingBll.InsertUserTraining(form.ToUserTrainingFromBll())?.Select(t => t.ToTraining()).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpGet("UpdateMostLevel/{id}/{userId}")]
        public IActionResult  UpdateMostLevel(int id,int userId)
        {
            try
            {
                int? resultid = _trainingBll.UpdateMostLevel(id);
                return Ok(_trainingBll.GetTrainingsByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("DeleteUserTraining/{trainingId}/{userId}")]
        public IActionResult DeleteUserTraining(int trainingId, int userId)
        {
            try
            {
                int? resultid = _trainingBll.DeleteUserTraining( trainingId,  userId);
                return Ok(_trainingBll.GetTrainingsByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

    }
}
