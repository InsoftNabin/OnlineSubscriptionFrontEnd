//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
//using Renci.SshNet;

//namespace OnlineSubscriptionFrontEnd.Classes
//{
//    public class FileProcessing
//    {
//    }
//}
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineSubscriptionFrontEnd.Classes
{
    public static class FileProcessing
    {
        public static byte[] ConvertToByteArray(IFormFile formFile)
        {
            byte[] SchoolLogoInByte = null;
            if (formFile.Length > 0)
            {
                using (var fs1 = formFile.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    SchoolLogoInByte = ms1.ToArray();
                }
            }
            return SchoolLogoInByte;
        }

        public static async Task<string> FileUpload(IFormFile File, string TokenNo, string FolderName)
        {
            try
            {
                string FtpInfo = await ApiCall.ApiCallWithString("SchoolFtpManagement/FtpDetails", TokenNo, "Post");

                JArray jArray = (JArray)JsonConvert.DeserializeObject(FtpInfo);
                string SchoolCode = jArray[0]["SchoolCode"].ToString();
                string FtpUrl = jArray[0]["HostedFTP"].ToString();

                string one = FtpUrl;
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo(one, "ftpadmin", "RajRana@Insoft")))
                {
                    client.Connect();

                    client.ChangeDirectory("../../var/www/insoft/fileuploads/" + SchoolCode + "/" + FolderName + "");

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





                //byte[] fileBytes = null;

                //Random random1 = new Random();
                //string InitialName = random1.Next().ToString();
                //string WithMidelName = InitialName + "-1543-";
                //string LastName = File.FileName;

                //string FileNameForUpload = InitialName + WithMidelName + LastName;
                //string SpaceRemovedFileNameForUpload = FileNameForUpload.Replace(" ", "-");
                //var ms = new MemoryStream();
                //File.CopyTo(ms);
                //fileBytes = ms.ToArray();

                //// string FTPServer = "ftp://182.50.135.97/";
                //string FTPServer = FtpUrl + "/" + SchoolCode + "/" + FolderName.Trim();

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer + "/" + SpaceRemovedFileNameForUpload);
                //request.Method = WebRequestMethods.Ftp.UploadFile;

                //string UserName = "ftpacademe";
                //string Password = "Nepal@54321";
                //request.Credentials = new NetworkCredential(UserName, Password);
                //request.ContentLength = fileBytes.Length;
                //request.UsePassive = true;
                //request.UseBinary = true;
                //request.Timeout = 60000000;
                //request.ServicePoint.ConnectionLimit = fileBytes.Length;
                //request.EnableSsl = false;

                //using (Stream requestStream = request.GetRequestStream())
                //{
                //    requestStream.Write(fileBytes, 0, fileBytes.Length);
                //    requestStream.Close();
                //}

                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //response.Close();
                //return SpaceRemovedFileNameForUpload;






                //    byte[] fileBytes = null;

                //    //string FileName = Guid.NewGuid().ToString();
                //    //string FileExtention = Path.GetExtension(File.FileName);
                //    //string FileNameForUpload = FileName + FileExtention;

                //    Random random1 = new Random();
                //    string InitialName = random1.Next().ToString();
                //    string WithMidelName = InitialName + "-1543-";
                //    string LastName = File.FileName;

                //    // string FileName = Guid.NewGuid().ToString();
                //    // string FileExtention = Path.GetExtension(File.FileName);
                //    // string FileNameForUpload = FileName + FileExtention;
                //    string FileNameForUpload = InitialName + WithMidelName + LastName;

                //    string RemoveSpace = FileNameForUpload.Replace(" ", "-");

                //    var ms = new MemoryStream();
                //    File.CopyTo(ms);
                //    fileBytes = ms.ToArray();

                //    string FTPServer = "ftp://insoftnepal.com";
                //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer + "/" + RemoveSpace);
                //    request.Method = WebRequestMethods.Ftp.UploadFile;

                //    string UserName = "ftpacademe";
                //    string Password = "Nepal@54321";
                //    request.Credentials = new NetworkCredential(UserName, Password);

                //    // request.Credentials = new NetworkCredential();
                //    request.ContentLength = fileBytes.Length;
                //    request.UsePassive = true;
                //    request.UseBinary = true;
                //    request.Timeout = 600000000;
                //    request.ServicePoint.ConnectionLimit = fileBytes.Length;
                //    request.EnableSsl = false;

                //    using (Stream requestStream = request.GetRequestStream())
                //    {
                //        requestStream.Write(fileBytes, 0, fileBytes.Length);
                //        requestStream.Close();
                //    }

                //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //    response.Close();
                //    return RemoveSpace;


                //    //string FileName = Guid.NewGuid().ToString();
                //    //string FileExtention = Path.GetExtension(File.FileName);
                //    //string FileNameForUpload = FileName + FileExtention;
                //    //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\Image", FileNameForUpload);
                //    //using (var stream = new FileStream(path, FileMode.Create))
                //    //{
                //    //    await File.CopyToAsync(stream);
                //    //}
                //    //return FileNameForUpload;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static async Task<string> FileUploadForSeparateDatabase(IFormFile File, string TokenNo, string FolderName)
        {
            try
            {
                string FtpInfo = await ApiCall.ApiCallWithString("SchoolFtpManagement/FtpDetailsWithSeparatedatabase", TokenNo, "Post");

                JArray jArray = (JArray)JsonConvert.DeserializeObject(FtpInfo);
                string SchoolCode = jArray[0]["SchoolCode"].ToString();
                string FtpUrl = jArray[0]["HostedFTP"].ToString();

                string one = FtpUrl;
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo(one, "ftpadmin", "RajRana@Insoft")))
                {
                    client.Connect();

                    client.ChangeDirectory("../../var/www/insoft/fileuploads/" + SchoolCode + "/" + FolderName + "");

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





                //byte[] fileBytes = null;

                //Random random1 = new Random();
                //string InitialName = random1.Next().ToString();
                //string WithMidelName = InitialName + "-1543-";
                //string LastName = File.FileName;

                //string FileNameForUpload = InitialName + WithMidelName + LastName;
                //string SpaceRemovedFileNameForUpload = FileNameForUpload.Replace(" ", "-");
                //var ms = new MemoryStream();
                //File.CopyTo(ms);
                //fileBytes = ms.ToArray();

                //// string FTPServer = "ftp://182.50.135.97/";
                //string FTPServer = FtpUrl + "/" + SchoolCode + "/" + FolderName.Trim();

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer + "/" + SpaceRemovedFileNameForUpload);
                //request.Method = WebRequestMethods.Ftp.UploadFile;

                //string UserName = "ftpacademe";
                //string Password = "Nepal@54321";
                //request.Credentials = new NetworkCredential(UserName, Password);
                //request.ContentLength = fileBytes.Length;
                //request.UsePassive = true;
                //request.UseBinary = true;
                //request.Timeout = 60000000;
                //request.ServicePoint.ConnectionLimit = fileBytes.Length;
                //request.EnableSsl = false;

                //using (Stream requestStream = request.GetRequestStream())
                //{
                //    requestStream.Write(fileBytes, 0, fileBytes.Length);
                //    requestStream.Close();
                //}

                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //response.Close();
                //return SpaceRemovedFileNameForUpload;






                //    byte[] fileBytes = null;

                //    //string FileName = Guid.NewGuid().ToString();
                //    //string FileExtention = Path.GetExtension(File.FileName);
                //    //string FileNameForUpload = FileName + FileExtention;

                //    Random random1 = new Random();
                //    string InitialName = random1.Next().ToString();
                //    string WithMidelName = InitialName + "-1543-";
                //    string LastName = File.FileName;

                //    // string FileName = Guid.NewGuid().ToString();
                //    // string FileExtention = Path.GetExtension(File.FileName);
                //    // string FileNameForUpload = FileName + FileExtention;
                //    string FileNameForUpload = InitialName + WithMidelName + LastName;

                //    string RemoveSpace = FileNameForUpload.Replace(" ", "-");

                //    var ms = new MemoryStream();
                //    File.CopyTo(ms);
                //    fileBytes = ms.ToArray();

                //    string FTPServer = "ftp://insoftnepal.com";
                //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer + "/" + RemoveSpace);
                //    request.Method = WebRequestMethods.Ftp.UploadFile;

                //    string UserName = "ftpacademe";
                //    string Password = "Nepal@54321";
                //    request.Credentials = new NetworkCredential(UserName, Password);

                //    // request.Credentials = new NetworkCredential();
                //    request.ContentLength = fileBytes.Length;
                //    request.UsePassive = true;
                //    request.UseBinary = true;
                //    request.Timeout = 600000000;
                //    request.ServicePoint.ConnectionLimit = fileBytes.Length;
                //    request.EnableSsl = false;

                //    using (Stream requestStream = request.GetRequestStream())
                //    {
                //        requestStream.Write(fileBytes, 0, fileBytes.Length);
                //        requestStream.Close();
                //    }

                //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //    response.Close();
                //    return RemoveSpace;


                //    //string FileName = Guid.NewGuid().ToString();
                //    //string FileExtention = Path.GetExtension(File.FileName);
                //    //string FileNameForUpload = FileName + FileExtention;
                //    //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\Image", FileNameForUpload);
                //    //using (var stream = new FileStream(path, FileMode.Create))
                //    //{
                //    //    await File.CopyToAsync(stream);
                //    //}
                //    //return FileNameForUpload;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public static async Task<string> FileUploadwithSchoolInitial(IFormFile File, string SchoolInitial, string FolderName)
        {
            try
            {

                string FtpInfo = await ApiCall.ApiCallWithString("SchoolFtpManagement/FtpDetailsBySchoolInitial", SchoolInitial, "Post");

                JArray jArray = (JArray)JsonConvert.DeserializeObject(FtpInfo);
                string SchoolCode = jArray[0]["SchoolCode"].ToString();
                string FtpUrl = jArray[0]["HostedFTP"].ToString();

                string one = FtpUrl;
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo(one, "ftpadmin", "RajRana@Insoft")))
                {
                    client.Connect();

                    client.ChangeDirectory("../../var/www/insoft/fileuploads/" + SchoolCode + "/" + FolderName);

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



                //string FtpInfo = await ApiCall.ApiCallWithString("SchoolFtpManagement/FtpDetailsBySchoolInitial", SchoolInitial, "Post");

                //JArray jArray = (JArray)JsonConvert.DeserializeObject(FtpInfo);
                //string SchoolCode = jArray[0]["SchoolCode"].ToString();
                //string FtpUrl = jArray[0]["HostedFTP"].ToString();


                //byte[] fileBytes = null;

                //Random random1 = new Random();
                //string InitialName = random1.Next().ToString();
                //string WithMidelName = InitialName + "-1543-";
                //string LastName = File.FileName;

                //string FileNameForUpload = InitialName + WithMidelName + LastName;
                //string SpaceRemovedFileNameForUpload = FileNameForUpload.Replace(" ", "-");
                //var ms = new MemoryStream();
                //File.CopyTo(ms);
                //fileBytes = ms.ToArray();

                //// string FTPServer = "ftp://182.50.135.97/";
                //string FTPServer = FtpUrl + "/" + SchoolCode + "/" + FolderName.Trim();

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer + "/" + SpaceRemovedFileNameForUpload);
                //request.Method = WebRequestMethods.Ftp.UploadFile;

                //string UserName = "ftpacademe";
                //string Password = "Nepal@54321";
                //request.Credentials = new NetworkCredential(UserName, Password);
                //request.ContentLength = fileBytes.Length;
                //request.UsePassive = true;
                //request.UseBinary = true;
                //request.Timeout = 60000000;
                //request.ServicePoint.ConnectionLimit = fileBytes.Length;
                //request.EnableSsl = false;

                //using (Stream requestStream = request.GetRequestStream())
                //{
                //    requestStream.Write(fileBytes, 0, fileBytes.Length);
                //    requestStream.Close();
                //}

                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //response.Close();
                //return SpaceRemovedFileNameForUpload;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> FileUploadInMainFolder(IFormFile File, string TokenNo, string FolderName)
        {
            try
            {

                string FtpInfo = await ApiCall.ApiCallWithString("SchoolFtpManagement/FtpDetails", TokenNo, "Post");

                JArray jArray = (JArray)JsonConvert.DeserializeObject(FtpInfo);
                string SchoolCode = jArray[0]["SchoolCode"].ToString();
                string FtpUrl = jArray[0]["HostedFTP"].ToString();
                //string FtpUrl = "10.48.1.5";
                string one = FtpUrl;
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo(one, "ftpadmin", "RajRana@Insoft")))
                {
                    client.Connect();

                    client.ChangeDirectory("../../var/www/insoft/fileuploads/" + FolderName + "");

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



                //string FtpInfo = await ApiCall.ApiCallWithString("SchoolFtpManagement/FtpDetails", TokenNo, "Post");

                //JArray jArray = (JArray)JsonConvert.DeserializeObject(FtpInfo);
                //string SchoolCode = jArray[0]["SchoolCode"].ToString();
                //string FtpUrl = jArray[0]["HostedFTP"].ToString();
                //byte[] fileBytes = null;

                //Random random1 = new Random();
                //string InitialName = random1.Next().ToString();
                //string WithMidelName = InitialName + "-1543-";
                //string LastName = File.FileName;

                //string FileNameForUpload = InitialName + WithMidelName + LastName;
                //string SpaceRemovedFileNameForUpload = FileNameForUpload.Replace(" ", "-");
                //var ms = new MemoryStream();
                //File.CopyTo(ms);
                //fileBytes = ms.ToArray();

                //// string FTPServer = "ftp://182.50.135.97/";
                //string FTPServer = FtpUrl +"/"+FolderName.Trim();

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer + "/" + SpaceRemovedFileNameForUpload);
                //request.Method = WebRequestMethods.Ftp.UploadFile;

                //string UserName = "ftpacademe";
                //string Password = "Nepal@54321";
                //request.Credentials = new NetworkCredential(UserName, Password);
                //request.ContentLength = fileBytes.Length;
                //request.UsePassive = true;
                //request.UseBinary = true;
                //request.Timeout = 60000000;
                //request.ServicePoint.ConnectionLimit = fileBytes.Length;
                //request.EnableSsl = false;

                //using (Stream requestStream = request.GetRequestStream())
                //{
                //    requestStream.Write(fileBytes, 0, fileBytes.Length);
                //    requestStream.Close();
                //}

                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //response.Close();
                //return SpaceRemovedFileNameForUpload;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
