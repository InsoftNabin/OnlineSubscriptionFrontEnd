using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models.Insoft;
using OnlineSubscriptionFrontEnd.Classes;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class AgentReportController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo == null)
                {
                    return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
                }
                else
                {
                    ViewBag.Role = HttpContext.Session.GetString("Role");
                    return View();
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
        public async Task<IActionResult> GetAgentReport([FromBody] Customer abc)
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
                    abc.TokenNo = TokenNo;
                    string i = await ApiCall.ApiCallWithObject("SubscriptionReport/GetAgentReport", abc, "Post");
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
    }
}
