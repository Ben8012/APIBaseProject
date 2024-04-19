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
using Tools;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using DAL.Interfaces;
using DAL.Models.DTO;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize("Auth")]
    public class UserController : ControllerBase
    {

        private readonly IUserBll _userBll;
        private readonly ILogger _logger;
        private readonly ITokenManager _token;
        private readonly Connection _connection;
        

        public UserController(ILogger<UserController> logger, IUserBll userBll, ITokenManager token, Connection connection)
        {
            _userBll = userBll;
            _logger = logger;
            _token = token;
            _connection = connection;
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
                User user = _userBll.GetById(id)?.ToUser();
                user.Token = _token.GenerateJWTUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Friends/{id}")]
        public IActionResult GetFriendsUserId(int id)
        {
            try
            {
                return Ok(_userBll.GetFriendsUserId(id)?.Select(u => u.ToUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Likers/{id}")]
        public IActionResult GetLikersByUserId(int id)
        {
            try
            {
                return Ok(_userBll.GetLikersByUserId(id)?.Select(u => u.ToUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'operation a echoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }


        [HttpGet("Likeds/{id}")]
        public IActionResult GetLikedsByUserId(int id)
        {
            try
            {
                return Ok(_userBll.GetLikedsByUserId(id)?.Select(u => u.ToUser()));
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
            //form.AdressId = 1;
            //form.Phone = null;
            //form.InsuranceNumber = null;

            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            try
            {
                User user = _userBll.Insert(form.ToAddUserFromBll())?.ToUser();
                if (user is null)
                {
                    return BadRequest(new { Message = "L'utilisateur n'a pas été trouvé " });
                }
                user.Token = _token.GenerateJWTUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
               if(ex is SqlException sqlEx )
                {
                    return BadRequest(new { Message = "Email deja prit", ErrorMessage = sqlEx.Message });
                }
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState update est invalide" });
            form.Id = id;
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
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState Login est invalide" });
            try
            {
                User? user = _userBll.Login(form.ToLoginFormBll()).ToUser();
                if (user is null)
                {
                    return BadRequest(new { Message = "L'utilisateur n'a pas été trouvé " });
                }
                user.Token = _token.GenerateJWTUser(user);
                return Ok(user);
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
                    return Ok(_userBll.GetFriendsUserId(form.LikerId)?.Select(u => u.ToUser()));
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
                    return Ok(_userBll.GetFriendsUserId(form.LikerId)?.Select(u => u.ToUser()));
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

                User? user = _userBll.GetById(id)?.ToUser();
                if (user is null)
                {
                    return BadRequest(new { Message = "L'utilisateur n'a pas été trouvé " });
                }
                user.Token = form.TokenString;
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "l'insertion a échoué, contactez l'admin", ErrorMessage = ex.Message });
            }
        }

        //[HttpGet("Organisation")]
        //public IActionResult GetOrganistionByUserId()
        //{

        //    if (!ModelState.IsValid) return BadRequest(new { Message = "ModelState insert est invalide" });

        //    Command command = new Command(
        //           @"SELECT [user_id] , [name], [level], refNumber, picture, User_Organisation.createdAt 
        //            FROM Organisation  
        //            JOIN User_Organisation ON Organisation.Id = organisation_id; "
        //           , false
        //        );
         
           
        //    try
        //    {
        //        return Ok(_connection.ExecuteReader(command, dr => dr.ToOrganisation()));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        throw ex;
        //    }
        //}

        //private UserWithToken GetUserWithToken(User user)
        //{
        //    return new UserWithToken()
        //    {
        //        Id = user.Id,
        //        Firstname = user.Firstname,
        //        Lastname = user.Lastname,
        //        Email = user.Email,
        //        Birthdate = user.Birthdate,
        //        CreatedAt = user.CreatedAt,
        //        UpdatedAt = user.UpdatedAt,
        //        Token = _token.GenerateJWTUser(user)
        //    };
        //}
    }
}
