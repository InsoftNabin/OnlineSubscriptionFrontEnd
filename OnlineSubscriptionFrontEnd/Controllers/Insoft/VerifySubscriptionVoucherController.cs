using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models.Insoft;
using OnlineSubscriptionFrontEnd.Classes;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class VerifySubscriptionVoucherController : Controller
    {
        public IActionResult Index()
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
                    ViewBag.Role = HttpContext.Session.GetString("Role");

                    return View();
                }

            }
            catch (Exception ex)
            {
                string Exception = ex.ToString();
                TempData["Exception"] = Exception;
                return RedirectToAction("ErrorPage", "Customer");

            }
        }

        [HttpPost]
        public async Task<IActionResult> getSubscriptionVoucher()
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
                    string i = await ApiCall.ApiCallWithString("Subscription/getVouchersForVerification", TokenNo, "Post");
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
