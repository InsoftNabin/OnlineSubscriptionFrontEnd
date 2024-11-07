using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models;
using OnlineSubscriptionFrontEnd.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Renci.SshNet;

namespace OnlineSubscriptionFrontEnd.Controllers
{

    public class RegisterController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel rg)
        {
            try
            {
                var result = await ApiCall.ApiCallWithObject("User/Register", rg, "POST");
                var success = JsonConvert.DeserializeObject<int>(result);
                if (success == 1)
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Error");
                }



            }
            catch (Exception ex)
            {
                return Ok("Error");
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> UploadPhoto1([FromBody] IFormFile files)
        //{
        //    try
        //    {
        //        string TokenNo = HttpContext.Session.GetString("TokenNo");
        //        string PictureName = await FileUpload(TokenNo, files, "Subscription");
        //        return Ok(PictureName);

        //    }
        //    catch (Exception ex)
        //    {
        //        string Exception = ex.ToString();
        //        return Ok("Exception:" + Exception);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IList<IFormFile> files)
        {
            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }
                else
                {
                    string PictureName = await FileProcessing.FileUpload(files[0], TokenNo, "ReadingMaterials");
                    return Ok(PictureName);
                }
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                return Ok("Exception:" + Exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto1([FromForm] IFormFile files)
        {
            try
            {
                if (files == null || files.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                string TokenNo = HttpContext.Session.GetString("TokenNo");
                string PictureName = await FileUpload(TokenNo, files, "Subscription");
                return Ok(PictureName);
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                return StatusCode(500, "Exception: " + exception); // Return a server error with the exception details
            }
        }




        public static async Task<string> FileUpload(string TokenNo, IFormFile File, string FolderName)
        {
            try
            {
                string FtpInfo = await ApiCall.ApiCallWithString("User/FtpDetails", TokenNo, "POST");
                string one = JsonConvert.DeserializeObject<string>(FtpInfo);

                using (SftpClient client = new SftpClient(new PasswordConnectionInfo(one, "ftpadmin", "RajRana@Insoft")))
                {
                    client.Connect();

                    client.ChangeDirectory("../../var/www/insoft/fileuploads/Subscription/");

                    var memoryStream = new MemoryStream();
                    await File.CopyToAsync(memoryStream);


                    Random random1 = new Random();
                    string InitialName = random1.Next().ToString();
                    string WithMidelName = InitialName + "-1543-";
                    string LastName = File.FileName;

                    string FileNameForUpload = InitialName + WithMidelName + LastName;
                    string SpaceRemovedFileNameForUpload = FileNameForUpload.Replace(" ", "-");


                    using (var uplfileStream = File.OpenReadStream())
                    {
                        client.UploadFile(uplfileStream, SpaceRemovedFileNameForUpload);
                    }
                    return SpaceRemovedFileNameForUpload;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}


