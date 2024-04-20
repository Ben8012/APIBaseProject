using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Models.DTO.UserAPI;
using Tools;
using System;
using Microsoft.Extensions.Hosting;
using DAL.Models.DTO;
using System.Data.Common;
using System.Drawing;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize("Auth")]
    public class ImageController : ControllerBase
    {
        private readonly string _uploadFolder;
        private readonly string _insuranceImage;
        private readonly string _levelImage;
        private readonly string _certificatImage;
        private readonly string _diveplaceImage;
        private readonly string _diveplacePlan;

        private readonly Connection _connection;


        public ImageController(Connection connection)
        {
          
            _uploadFolder = Path.Combine(Directory.GetCurrentDirectory() + "\\Images", "", "ProfilImages");
            _insuranceImage = Path.Combine(Directory.GetCurrentDirectory() + "\\Images", "", "InsuranceImages");
            _levelImage = Path.Combine(Directory.GetCurrentDirectory() + "\\Images", "", "LevelImages");
            _certificatImage = Path.Combine(Directory.GetCurrentDirectory() + "\\Images", "", "CertificatImages");
            _diveplaceImage = Path.Combine(Directory.GetCurrentDirectory() + "\\Images", "", "DiveplaceImages");
            _diveplacePlan = Path.Combine(Directory.GetCurrentDirectory() + "\\Images", "", "DiveplacePlan");
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
            _connection = connection;
        }


        [HttpPost("ProfilImage/{id}")]
        public async Task<IActionResult> InsertProfilImage(int id)
        {
            var test = Directory.GetCurrentDirectory();

            if (!Request.HasFormContentType)
            {
                return BadRequest("The request doesn't contain a valid form content.");
            }

            var form = Request.Form;

            var files = form.Files;

            string guidImage;
            Command command1 = new Command(@"SELECT guidImage 
                                            FROM [User]  
                                            WHERE Id=@Id ; ", false);
            command1.AddParameter("Id", id);

            try
            {
                guidImage = _connection.ExecuteScalar(command1) as string;
                if(!String.IsNullOrEmpty(guidImage))
                {
                    var filePath = Path.Combine(_uploadFolder, guidImage);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var fileName = file.FileName;
                    var filePath = Path.Combine(_uploadFolder, fileName);

                    if (!System.IO.File.Exists(filePath)) // Vérifiez si le fichier existe déjà
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Command command = new Command(@"UPDATE [User] SET 
                                        guidImage = @guidImage
                                        WHERE Id=@Id ; ", false);
                        command.AddParameter("Id", id);
                        command.AddParameter("guidImage", fileName);
                          
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
            }
            return Ok(new {Message = "ok"});
        }

        [HttpGet("ProfilImage/{imageName}")]
        public IActionResult GetProfilImage(string imageName)
        {
            var filePath = Path.Combine(_uploadFolder, imageName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(imageFileStream, "image/jpeg"); // Modifier le type de contenu en fonction du type d'image que vous stockez
        }


        //[HttpPost("InsuranceImage/{id}")]
        //public async Task<IActionResult> InsertInsuranceImage(int id)
        //{
        //    var test = Directory.GetCurrentDirectory();

        //    if (!Request.HasFormContentType)
        //    {
        //        return BadRequest("The request doesn't contain a valid form content.");
        //    }

        //    var form = Request.Form;

        //    var files = form.Files;

        //    string guidInsurance;
        //    Command command1 = new Command(@"SELECT guidInsurance 
        //                                    FROM [User]  
        //                                    WHERE Id=@Id ; ", false);
        //    command1.AddParameter("Id", id);

        //    try
        //    {
        //        guidInsurance = _connection.ExecuteScalar(command1) as string;
        //        if (!String.IsNullOrEmpty(guidInsurance))
        //        {
        //            var filePath = Path.Combine(_insuranceImage, guidInsurance);

        //            if (System.IO.File.Exists(filePath))
        //            {
        //                System.IO.File.Delete(filePath);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            var guid = Guid.NewGuid().ToString();
        //            var fileName = guid + Path.GetExtension(file.FileName);
        //            var filePath = Path.Combine(_insuranceImage, fileName);

        //            if (!System.IO.File.Exists(filePath)) // Vérifiez si le fichier existe déjà
        //            {
        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    await file.CopyToAsync(stream);
        //                }
        //                Command command = new Command(@"UPDATE [User] SET 
        //                                guidInsurance = @guidInsurance
        //                                WHERE Id=@Id ; ", false);
        //                command.AddParameter("Id", id);
        //                command.AddParameter("guidInsurance", guid);

        //                try
        //                {
        //                    _connection.ExecuteScalar(command);
        //                }
        //                catch (Exception ex)
        //                {

        //                    throw ex;
        //                }
        //            }
        //        }
        //    }
        //    return Ok(new { Message = "ok" });
        //}

        //[HttpGet("InsuranceImage/{imageName}")]
        //public IActionResult GetInsuranceImage(string imageName)
        //{
        //    var filePath = Path.Combine(_insuranceImage, imageName);

        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return NotFound();
        //    }

        //    var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        //    return File(imageFileStream, "image/jpeg"); 
        //}

     
        [HttpPost("LevelImage/{id}")]
        public async Task<IActionResult> InsertLevelImage(int id)
        {
            var test = Directory.GetCurrentDirectory();

            if (!Request.HasFormContentType)
            {
                return BadRequest("The request doesn't contain a valid form content.");
            }

            var form = Request.Form;

            var files = form.Files;

            string guidLevel;
            Command command1 = new Command(@"SELECT guidLevel 
                                            FROM [User]  
                                            WHERE Id=@Id ; ", false);
            command1.AddParameter("Id", id);

            try
            {
                guidLevel = _connection.ExecuteScalar(command1) as string;
                if (!String.IsNullOrEmpty(guidLevel))
                {
                    var filePath = Path.Combine(_levelImage, guidLevel);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var fileName = file.FileName;
                    var filePath = Path.Combine(_levelImage, fileName);

                    if (!System.IO.File.Exists(filePath)) // Vérifiez si le fichier existe déjà
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Command command = new Command(@"UPDATE [User] SET 
                                        guidLevel = @guidLevel
                                        WHERE Id=@Id ; ", false);
                        command.AddParameter("Id", id);
                        command.AddParameter("guidLevel", fileName);

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
            }
            return Ok(new { Message = "ok" });
        }

        [HttpGet("LevelImage/{imageName}")]
        public IActionResult GetLevelImage(string imageName)
        {
            var filePath = Path.Combine(_levelImage, imageName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(imageFileStream, "image/jpeg");
        }

      
        [HttpPost("CertificatImage/{id}")]
        public async Task<IActionResult> InsertCertificatImage(int id)
        {
            var test = Directory.GetCurrentDirectory();

            if (!Request.HasFormContentType)
            {
                return BadRequest("The request doesn't contain a valid form content.");
            }

            var form = Request.Form;

            var files = form.Files;

            string guidCertificat;
            Command command1 = new Command(@"SELECT guidCertificat 
                                            FROM [User]  
                                            WHERE Id=@Id ; ", false);
            command1.AddParameter("Id", id);

            try
            {
                guidCertificat = _connection.ExecuteScalar(command1) as string;
                if (!String.IsNullOrEmpty(guidCertificat))
                {
                    var filePath = Path.Combine(_certificatImage, guidCertificat);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var fileName = file.FileName;
                    var filePath = Path.Combine(_certificatImage, fileName);

                    if (!System.IO.File.Exists(filePath)) // Vérifiez si le fichier existe déjà
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Command command = new Command(@"UPDATE [User] SET 
                                        guidCertificat = @guidCertificat
                                        WHERE Id=@Id ; ", false);
                        command.AddParameter("Id", id);
                        command.AddParameter("guidCertificat", fileName);

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
            }
            return Ok(new { Message = "ok" });
        }

        [HttpGet("CertificatImage/{imageName}")]
        public IActionResult GetCertificatImage(string imageName)
        {
            var filePath = Path.Combine(_certificatImage, imageName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(imageFileStream, "image/jpeg");
        }


        [HttpPost("SiteImage/{id}")]
        public async Task<IActionResult> InsertSiteImage(int id)
        {
            var test = Directory.GetCurrentDirectory();

            if (!Request.HasFormContentType)
            {
                return BadRequest("The request doesn't contain a valid form content.");
            }

            var form = Request.Form;

            var files = form.Files;

            string guidImage;
            Command command1 = new Command(@"SELECT guidImage
                                            FROM [Diveplace]  
                                            WHERE Id=@Id ; ", false);
            command1.AddParameter("Id", id);

            try
            {
                guidImage = _connection.ExecuteScalar(command1) as string;
                if (!String.IsNullOrEmpty(guidImage))
                {
                    var filePath = Path.Combine(_diveplaceImage, guidImage);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var fileName = file.FileName;
                    var filePath = Path.Combine(_diveplaceImage, fileName);

                    if (!System.IO.File.Exists(filePath)) // Vérifiez si le fichier existe déjà
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Command command = new Command(@"UPDATE [Diveplace] SET 
                                        guidImage = @guidImage
                                        WHERE Id=@Id ; ", false);
                        command.AddParameter("Id", id);
                        command.AddParameter("guidImage", fileName);

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
            }
            return Ok(new { Message = "ok" });
        }

        [HttpGet("SiteImage/{imageName}")]
        public IActionResult GetSiteImage(string imageName)
        {
            var filePath = Path.Combine(_diveplaceImage, imageName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(imageFileStream, "image/jpeg");
        }

        [HttpPost("SitePlan/{id}")]
        public async Task<IActionResult> InsertSitePlan(int id)
        {
            var test = Directory.GetCurrentDirectory();

            if (!Request.HasFormContentType)
            {
                return BadRequest("The request doesn't contain a valid form content.");
            }

            var form = Request.Form;

            var files = form.Files;

            string guidPlan;
            Command command1 = new Command(@"SELECT guidMap
                                            FROM [Diveplace]  
                                            WHERE Id=@Id ; ", false);
            command1.AddParameter("Id", id);

            try
            {
                guidPlan = _connection.ExecuteScalar(command1) as string;
                if (!String.IsNullOrEmpty(guidPlan))
                {
                    var filePath = Path.Combine(_diveplacePlan, guidPlan);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var fileName = file.FileName;
                    var filePath = Path.Combine(_diveplacePlan, fileName);

                    if (!System.IO.File.Exists(filePath)) // Vérifiez si le fichier existe déjà
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Command command = new Command(@"UPDATE [Diveplace] SET 
                                        guidMap = @guidMap
                                        WHERE Id=@Id ; ", false);
                        command.AddParameter("Id", id);
                        command.AddParameter("guidMap", fileName);

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
            }
            return Ok(new { Message = "ok" });
        }

        [HttpGet("SitePlan/{imageName}")]
        public IActionResult GetSitePlan(string imageName)
        {
            var filePath = Path.Combine(_diveplacePlan, imageName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(imageFileStream, "image/jpeg");
        }


    }

}
