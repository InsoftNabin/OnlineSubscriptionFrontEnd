using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return Ok("Invalid email address.");

            }
        }
        [HttpPost]
        public async Task<IActionResult> GetCode([FromBody] SendCode sc)
        {
            try
            {
                var result = await ApiCall.ApiCallWithObject("EmailMessaging/GetCode", sc, "POST");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Error");

            }

        }

    }
}


