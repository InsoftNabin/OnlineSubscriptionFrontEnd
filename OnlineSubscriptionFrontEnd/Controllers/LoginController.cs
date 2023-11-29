using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models;
using OnlineSubscriptionFrontEnd.Classes;
using Newtonsoft.Json; // Added for JsonConvert


namespace OnlineSubscriptionFrontEnd.Controllers
{

    public class LoginController : Controller
    {
        string baseurl = Startup.baseapiurl;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyUser([FromBody] Login login)
        {
            try
            {
                var value = await ApiCall.ApiCallWithObject("ValidateUser/ValidateUser", login, "Post");
                var result = JsonConvert.DeserializeObject<loginValidator>(value);
                if (result.status == 200)
                {
                    HttpContext.Session.SetString("TokenNo", result.tokenNo);
                    return Ok("Success");
                }
                else
                {
                    // TempData["MessageType"] = "Ërror";
                    // TempData["Message"] = "Invalid UserName Or Password";
                    return Ok("Error");
                }
            }
            catch (Exception ex)
            {
                return Ok("error");
            }
        }


    }
}


