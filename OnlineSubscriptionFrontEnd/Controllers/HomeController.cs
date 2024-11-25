using System.Text;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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


        public IActionResult viewNewPage()
        {

            return View();
        }
        public IActionResult PayNowPage()
        {

            return View();
        }


        [HttpPost]
        public async Task<JsonResult> CreateInvoice([FromBody] InvoiceData invoiceData)
        {
           
            TempData["InvoiceData"] = JsonConvert.SerializeObject(invoiceData);

            return Json(new { success = true, message = "Invoice Data Received" });
        }


        public IActionResult InvoicePage()
        {
            var invoiceDataJson = TempData["InvoiceData"] as string;
            if (invoiceDataJson != null)
            {
                var invoiceData = JsonConvert.DeserializeObject<InvoiceData>(invoiceDataJson);
                return View(invoiceData);
            }

            return RedirectToAction("Index", "Home");
        }

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
        public async Task<IActionResult> getInvoiceForPrint([FromBody] InvoiceData org)
        {
            var token = HttpContext.Session.GetString("TokenNo");
            if (token != null)
            {

                var result = await ApiCall.ApiCallWithObject("Customer/getInvoiceForPrint", org, "Post");
                return Ok(result);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }


        public async Task<IActionResult> External(string CustomerSubcriptionGuid)
        {

            LoginValidator lv = new LoginValidator();
            lv.CustomerSubscriptionGuid = CustomerSubcriptionGuid;


            var value = await ApiCall.ApiCallWithObject("ValidateUser/ValidateUserExternallink", lv, "Post");
            var result = JsonConvert.DeserializeObject<loginValidator>(value);

            if (result.status == 200)
            {
                HttpContext.Session.SetString("TokenNo", result.tokenNo);
                HttpContext.Session.SetString("UserName", result.UserName);
                ViewBag.Customer = result.Customer;
                ViewBag.Product = result.Product;
                return View("Index");
            }
            else
            {
                return Ok("400");
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


