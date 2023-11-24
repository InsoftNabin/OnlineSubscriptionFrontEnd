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

    public class RegisterController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel rg)
        {
            try
            {
                var newVAl = rg;
                return RedirectToAction("Index", "Login");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}


