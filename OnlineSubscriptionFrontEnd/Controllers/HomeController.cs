using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using DataServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OnlineSubscriptionFrontEnd.Controllers
{

    public class HomeController : Controller
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


    }
}


