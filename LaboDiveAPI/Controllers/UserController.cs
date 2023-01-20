using BLL.Interfaces;
using API.Mappers;
using API.Models.DTO.UserAPI;
using API.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models.Forms.UserAPI;
using BLL.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("Auth")]
    public class UserController : ControllerBase
    {

        private readonly IUserBll _userBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;

        public UserController(ILogger<UserController> logger, IUserBll userBll, ITokenManager token)
        {
            _userBll = userBll;
            _logger = logger;
            _token = token;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userBll.GetAll().Select(u => u.ToUser()));
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
                return Ok(_userBll.GetById(id)?.ToUser());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Friends/{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {
                return Ok(_userBll.GetContactById(id)?.Select(u => u.ToUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Insert([FromBody] AddUserForm form)
        {
            //form.Password = "Test1234=";
            //form.Email = "benjamin@mail.com";
            //form.FirstName = "Benjamin";
            //form.LastName = "Sterckx";
            //form.Birthdate = new DateTime(1980,12,10);
            form.AdressId = 1;
            //form.Phone = null;
            //form.InsuranceNumber = null;

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            try
            {
                return Ok(_userBll.Insert(form.ToAddUserFromBll())?.ToUser());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            try
            {
                return Ok(_userBll.Update(form.ToUpdateUserFormBll())?.ToUser());
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
                return Ok(_userBll.Delete(id));

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
                return Ok(_userBll.Enable(id));

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
                return Ok(_userBll.Disable(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("/api/User/Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            //form.Email = "benjamin@mail.com";
            //form.Password = "Test1234=";
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState Login est invalide" });
            try
            {
                User? user = _userBll.Login(form.ToLoginFormBll()).ToUser();

                if (user is null)
                {
                    return BadRequest(new { Message = "L'utilisateur n'a pas été trouvé " });
                }
                UserWithToken userWithToken = new UserWithToken()
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    Birthdate = user.Birthdate,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                    Token = _token.GenerateJWTUser(user)
                };

                return Ok(userWithToken);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "le login a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Like")]
        public IActionResult Like([FromBody] LikeForm form)
        {
             
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {
                int? valid = _userBll.Like(form.LikerId, form.LikedId);
                if (valid > 0)
                {
                    return Ok(_userBll.GetContactById(form.LikerId)?.Select(u => u.ToUser()));
                }
                return Ok(null);
               
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }

        [HttpPost("UnLike") ]
        public IActionResult UnLike([FromBody] LikeForm form)
        {
            try
            {
                int? valid = _userBll.UnLike(form.LikerId, form.LikedId);
                if (valid > 0)
                {
                    return Ok(_userBll.GetContactById(form.LikerId)?.Select(u => u.ToUser()));
                }
                return Ok(null);

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "la suppression a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Token")]
        public IActionResult GetUserByToken([FromBody] Token form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            try
            {

                JwtSecurityToken token = new JwtSecurityToken(jwtEncodedString: form.TokenString);
                int id = int.Parse( token.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value);

                return Ok(_userBll.GetById(id)?.ToUser());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }
    }
}
