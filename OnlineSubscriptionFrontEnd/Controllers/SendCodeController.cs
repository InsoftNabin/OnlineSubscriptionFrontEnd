using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models;


namespace OnlineSubscriptionFrontEnd.Controllers
{

    public class SendCodeController : Controller
    {
        string baseurl = Startup.baseapiurl;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmailAndSendCode([FromBody] SendCode sc)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(sc.ReceiverEmail);
                var result = await ApiCall.ApiCallWithObject("EmailMessaging/SendReceiptInEmail", sc, "POST");
                return Ok(result);
            }
            catch (FormatException)
            {
                return Ok("Error");

            }
        }
        public class VerificationResponse
        {
            public string VerificationCode { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> GetCode([FromBody] SendCode sc)
        {
            try
            {
                var result = await ApiCall.ApiCallWithObject("EmailMessaging/GetCode", sc, "POST");
                var rawArrayJson = JsonConvert.DeserializeObject<string>(result);
                var verificationList = JsonConvert.DeserializeObject<List<VerificationResponse>>(rawArrayJson);

                var checkOTP = verificationList?.FirstOrDefault();

                if (checkOTP != null && checkOTP.VerificationCode == "true")
                {
                    HttpContext.Session.SetString("RegOTPToken", sc.Gcode);

                    return Ok(new { success = true, message = "OTP verified", token = sc.Gcode });
                }

                return Ok(new { success = false, message = "OTP not verified" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }



        [HttpPost]
        public async Task<IActionResult> GetOTPCode([FromBody] SendCode sc)
        {
            try
            {
                var result = await ApiCall.ApiCallWithObject("EmailMessaging/GetOTPCode", sc, "POST");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }


    }
}


