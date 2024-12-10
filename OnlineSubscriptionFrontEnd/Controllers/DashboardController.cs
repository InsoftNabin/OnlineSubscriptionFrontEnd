using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models;
using OnlineSubscriptionFrontEnd.Models.Insoft;



namespace OnlineSubscriptionFrontEnd.Controllers
{
    public class DashboardController : Controller
    {

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
        [HttpPost]
        public async Task<IActionResult> GetUsers()
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                var token = HttpContext.Session.GetString("TokenNo");
                
                var sendJson = await ApiCall.ApiCallWithString("User/GetAllRegisteredName", token, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetAllRegisteredOrg([FromBody] verifyUser vu)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                vu.TokenNo = tokenval;
                var sendJson = await ApiCall.ApiCallWithObject("User/GetAllRegisteredOrgByCustomerId", vu, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }





        [HttpPost]
        public async Task<IActionResult> GetUnverifiedOrganizations()
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
                    string i = await ApiCall.ApiCallWithString("User/GetUnverifiedOrganizations", TokenNo, "Post");
                    return Ok(i);
                }

            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                TempData["Exception"] = Exception;
                return RedirectToAction("Index", "UnexpectedError");

            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrgdetailsByAdmin([FromBody] approveOrg ao)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                ao.TokenNo = tokenval;
                var sendJson = await ApiCall.ApiCallWithObject("User/UpdateOrgdetailsByAdmin", ao, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> getCusProdIdByToken([FromBody] approveOrg ao)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                ao.TokenNo = tokenval;
                var sendJson = await ApiCall.ApiCallWithObject("User/getCusProdIdByToken", ao, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }



        [HttpPost]
        public async Task<IActionResult> TrashOrgdetailsByAdmin([FromBody] approveOrg ao)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                ao.TokenNo = tokenval;
                var sendJson = await ApiCall.ApiCallWithObject("User/TrashOrgdetailsByAdmin", ao, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] sendEmail ao)
        {
            var tokenval = HttpContext.Session.GetString("TokenNo");
            if (tokenval != null)
            {
                ao.TokenNo = tokenval;
                var sendJson = await ApiCall.ApiCallWithObject("User/SendEmail", ao, "Post");
                return Json(sendJson);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }


        [HttpPost]
        public async Task<IActionResult> SendSMS([FromBody] SMSResponse sa)
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo is null)
                {
                    return Ok("-21");
                }
                else
                {
                    sa.TokenNo = tokenNo;
                    string successcode = await ApiCall.ApiCallWithObject("SMS/SendSMS", sa, "Post");

                    //  JObject templateList = (JObject)JsonConvert.DeserializeObject(successcode);
                    return Json(successcode);
                }
            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                return Ok("Exception:" + Exception);
            }
        }

    }
}


