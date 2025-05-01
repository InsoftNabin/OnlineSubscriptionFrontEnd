using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineSubscriptionFrontEnd.Models.FonePay;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.Insoft;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class SMSApiSetupController : Controller
    {
        public IActionResult Index()
        {

            string tokenNo = HttpContext.Session.GetString("TokenNo");

            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else {
                ViewBag.Role = HttpContext.Session.GetString("Role");
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> getSMSAPI()
        {
            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }

                string data = await ApiCall.ApiCallWithObject("/QRCodeForPayment/GetFonePayDetails1", TokenNo, "Post");
                string unescapedData = JsonConvert.DeserializeObject<string>(data);
                var fpluList = JsonConvert.DeserializeObject<List<FonepayLookup>>(unescapedData);

                return Json(fpluList);


            }
            catch (Exception e)
            {
                throw e;
            }
        }



        [HttpPost]
        public async Task<IActionResult> InsertUpdateSMSKeyDetails([FromBody] SMSSetup ai)
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo == null)
                {
                    return Ok("-21");
                }
                ai.TokenNo = tokenNo;
                var result = await ApiCall.ApiCallWithObject("SMSApiSetup/InsertUpdate", ai, "Post");
                return Ok(result);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.ToString();
                return RedirectToAction("Index", "UnexpectedError");
            }
        }



    }
}
