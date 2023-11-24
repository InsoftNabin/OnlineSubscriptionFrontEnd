using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models;
using OnlineSubscriptionFrontEnd.Classes;


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
        public async Task<IActionResult> VerifyUser([FromBody] LoginValidator login)
        {
            try
            {
                SLLogin sl = new SLLogin();
                SelectLoginInfo li = (SelectLoginInfo)await sl.GetLoginInfo(login);
                if (li.Status == 200)
                {
                    HttpContext.Session.SetString("TokenNo", li.TokenNo);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MessageType"] = "Ërror";
                    TempData["Message"] = "Invalid UserName Or Password";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}


