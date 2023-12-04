using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models;
using System.Drawing;

namespace resize_image
{
  class Resizer
  {
   
  }
}

namespace OnlineSubscriptionFrontEnd.Controllers
{

    public class HomeController : Controller
    {
public static Image ResizeImage(Image imgToResize, Size size)
    {
        return (Image)(new Bitmap(imgToResize, size));
    }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("TokenNo");
            if (token != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }
      public byte[]  ImageToByteArray(Image imageIn)
{
    using (var ms = new MemoryStream())
    {
        imageIn.Save(ms, imageIn.RawFormat);
        return ms.ToArray();
    }
}
        [HttpPost]
        public async Task<IActionResult> UploadOrganizationData([FromBody] orgData org)
        {
            var token = HttpContext.Session.GetString("TokenNo");
            if (token != null)
            {
                var image= org.ImageData;
                Bitmap mybitmap = new Bitmap(image);
                var imageVal = ResizeImage(mybitmap, new Size(40, 40));
                var newData = new OrganizationData();
                newData.Address = org.Address;
                newData.CompanyName = org.CompanyName;
                newData.ContactMobile = org.ContactMobile;
                newData.DisplayName = org.DisplayName;
                newData.ImageData = ImageToByteArray(imageVal);
                
                newData.ImageName = org.ImageName;
                newData.Initial = org.Initial;
                newData.Module = org.Module;
                newData.OrganizationMail = org.OrganizationMail;
                newData.OrganizationMotto = org.OrganizationMotto;
                newData.PanVatNo = org.PanVatNo;
                newData.PhoneNo = org.PhoneNo;
                newData.Token = org.Token;
                newData.Website = org.Website;
                newData.TokenNo = token;


                var result = await ApiCall.ApiCallWithObject("User/AddOrganization", newData, "Post");
                return Ok(result);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetModuleValues()
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                var token = HttpContext.Session.GetString("TokenNo");
                var data = new { TokenNo = token };
                var sendJson = await ApiCall.ApiCallWithObject("User/GetModules", data, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        //    using (MagickImage image = new MagickImage(@"YourImage.jpg"))
        //    {
        //        image.Format = image.Format; // Get or Set the format of the image.
        //        image.Resize(40, 40); // fit the image into the requested width and height. 
        //        image.Quality = 10; // This is the Compression level.
        //        image.Write("YourFinalImage.jpg");                 
        //     }
        [HttpPost]
        public async Task<IActionResult> GetOrganizations()
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                var token = HttpContext.Session.GetString("TokenNo");
                var data = new { TokenNo = token };
                var sendJson = await ApiCall.ApiCallWithObject("User/GetAllOrganizations", data, "Post");
                return Json(sendJson);

            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetSingleOrganization([FromBody] singleOrganization so)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                so.TokenNo = HttpContext.Session.GetString("TokenNo");
                var sendJson = await ApiCall.ApiCallWithObject("User/GetOrganizationsById", so, "Post");
                return Json(sendJson);

            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

    }


}


