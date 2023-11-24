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


namespace OnlineSubscriptionFrontEnd.Controllers
{

    public class VerifyEmailController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyCode(string code)
        {
            try
            {
                if (code == "1234")
                {
                    return RedirectToAction("Index", "Register");
                }
                else
                {
                    return Ok("fail");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}


