using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models;

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


        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("TokenNo");
           // var UserName = HttpContext.Session.GetString("UserName");

            if (token != null)
            {
                //TempData["UserName"] = UserName;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadOrganizationData([FromBody] orgData org)
        {
            var token = HttpContext.Session.GetString("TokenNo");
            if (token != null)
            {

                org.TokenNo = HttpContext.Session.GetString("TokenNo");
                var result = await ApiCall.ApiCallWithObject("User/AddOrganization", org, "Post");
                return Ok(result);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckInitialName([FromBody] orgData org)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
               
                org.TokenNo= tokenval;
                
                string sendJson = await ApiCall.ApiCallWithObject("User/CheckInitialName", org, "Post");
                return Json(sendJson);

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


        [HttpPost]
        public async Task<IActionResult> GetUserDetails()
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                var token = HttpContext.Session.GetString("TokenNo");
                var sendJson = await ApiCall.ApiCallWithObject("User/GetUserDetails", token, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        public async Task<IActionResult> DeleteSingleOrganization([FromBody] singleOrganization so)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                so.TokenNo = HttpContext.Session.GetString("TokenNo");
                var sendJson = await ApiCall.ApiCallWithObject("User/TrashOrganizationsById", so, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

    }


}


