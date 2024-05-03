using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Models.DTO.UserAPI;
using Tools;
using System;
using Microsoft.Extensions.Hosting;
using DAL.Models.DTO;
using System.Data.Common;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Auth")]
    public class ImageController : ControllerBase
    {
        private readonly Connection _connection;
       
        public ImageController(Connection connection)
        {
           _connection = connection;
        }


        [HttpPost("{id}/{type}")]
        public async Task<IActionResult> Insert(int id,string type)
        {
            try
            {
                var file = Request.Form.Files[0]; // Récupérer le fichier envoyé dans la requête

                if (file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        // Copier le contenu du fichier dans un flux mémoire
                        await file.CopyToAsync(stream);

                        // Convertir le flux en tableau d'octets
                        byte[] imageBytes = stream.ToArray();

                        // Insérer l'image blob dans la base de données
                        if (type == "ProfilImage")
                        {
                            Command command = new Command(@"UPDATE [User] SET guidImage = @guidImage WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidImage", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if(type == "InsuranceImage")
                        {
                            Command command = new Command(@"UPDATE [User] SET guidInsurance = @guidInsurance WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidInsurance", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (type == "LevelImage")
                        {
                            Command command = new Command(@"UPDATE [User] SET guidLevel = @guidLevel WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidLevel", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (type == "CertificatImage")
                        {
                            Command command = new Command(@"UPDATE [User] SET guidCertificat = @guidCertificat WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidCertificat", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (type == "SiteImage")
                        {
                            Command command = new Command(@"UPDATE [Diveplace] SET guidImage = @guidImage WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidImage", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (type == "SitePlan")
                        {
                            Command command = new Command(@"UPDATE [Diveplace] SET guidMap = @guidMap WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidMap", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (type == "OrganisationImage")
                        {              
                            Command command = new Command(@"UPDATE [Organisation] SET guidImage = @guidImage WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidImage", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else if (type == "TrainingImage")
                        {
                            Command command = new Command(@"UPDATE [Training] SET guidImage = @guidImage WHERE Id=@Id ;", false);
                            command.AddParameter("Id", id);
                            command.AddParameter("guidImage", imageBytes);
                            try
                            {
                                _connection.ExecuteScalar(command);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }

                    }
                    return Ok();
                }
                else
                {
                    return BadRequest("Empty file.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error uploading and inserting image.");
            }
        }

        [HttpGet("{id}/{type}")]
        public IActionResult GetImage(int id, string type)
        {
            byte[] imageBytes;
            try
            {
                // Récupérer l'image blob de la base de données
                if (type == "ProfilImage")
                {
                    Command command = new Command(@"SELECT [User].guidImage FROM [User] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "InsuranceImage")
                {
                    Command command = new Command(@"SELECT [User].guidInsurance FROM [User] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "LevelImage")
                {
                    Command command = new Command(@"SELECT [User].guidLevel FROM [User] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "CertificatImage")
                {
                    Command command = new Command(@"SELECT [User].guidCertificat FROM [User] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "SiteImage")
                {
                    Command command = new Command(@"SELECT [Diveplace].guidImage FROM [Diveplace] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "SitePlan")
                {
                    Command command = new Command(@"SELECT [Diveplace].guidMap FROM [Diveplace] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "OrganisationImage")
                {
                    Command command = new Command(@"SELECT [Organisation].guidImage FROM [Organisation] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "TrainingImage")
                {
                    Command command = new Command(@"SELECT [Training].guidImage FROM [Training] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else
                {
                    return NotFound("le type n'est pas connu"); // le type n'est pas connu
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error retrieving image from database.");
            }
        }


        [AllowAnonymous]
        [HttpGet("Allowed/{id}/{type}")]
        public IActionResult GetAllowedImage(int id, string type)
        {
            byte[] imageBytes;
            try
            {
                
                if (type == "SiteImage")
                {
                    Command command = new Command(@"SELECT [Diveplace].guidImage FROM [Diveplace] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "SitePlan")
                {
                    Command command = new Command(@"SELECT [Diveplace].guidMap FROM [Diveplace] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "OrganisationImage")
                {
                    Command command = new Command(@"SELECT [Organisation].guidImage FROM [Organisation] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else if (type == "TrainingImage")
                {
                    Command command = new Command(@"SELECT [Training].guidImage FROM [Training] WHERE id = @id; ", false);
                    command.AddParameter("id", id);
                    try
                    {
                        imageBytes = (byte[])_connection.ExecuteScalar(command);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    // Si l'image est trouvée, la renvoyer comme contenu de l'image
                    if (imageBytes != null)
                    {
                        return File(imageBytes, "image/jpeg"); // Spécifiez le type MIME approprié selon le format de votre image
                    }
                    else
                    {
                        return NotFound(); // Si l'image n'est pas trouvée, retourner une réponse 404
                    }
                }
                else
                {
                    return NotFound("le type n'est pas connu"); // le type n'est pas connu
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error retrieving image from database.");
            }
        }







    }

}
