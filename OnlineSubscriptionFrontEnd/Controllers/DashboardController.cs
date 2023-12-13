using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models;



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

    }
}


