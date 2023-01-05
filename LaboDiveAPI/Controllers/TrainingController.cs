﻿using API.Mappers;
using API.Models.Forms.Insurance;
using API.Models.Forms.Organisation;
using API.Models.Forms.Training;
using API.Tools;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                return Ok(_trainingBll.Delete(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


    }
}
