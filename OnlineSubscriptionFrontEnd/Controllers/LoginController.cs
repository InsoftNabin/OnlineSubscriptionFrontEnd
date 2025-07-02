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
using Newtonsoft.Json;
using Renci.SshNet;
using System.Security.Claims; // Added for JsonConvert
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

using Newtonsoft.Json;
using System.Xml.Linq;
using TwoFactorAuthNet;
using System.Data;
namespace OnlineSubscriptionFrontEnd.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        string baseurl = Startup.baseapiurl;
        private static TwoFactorAuthenticatorService _2FA;
     

        public LoginController(TwoFactorAuthenticatorService _2FAAuth)
        {
            _2FA = _2FAAuth;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Keysearch()
        {
            return View();
        }

        public ActionResult GetQR()
        {
            var name = User.FindFirst(ClaimTypes.Hash).Value;
           
            return StatusCode(StatusCodes.Status200OK, _2FA.GenerateUri(name));
        }

        [HttpPost]
        [AllowAnonymous]
       
        public async Task<IActionResult> VerifyUser([FromBody] Login login)
        {
            try
            {
                var value = await ApiCall.ApiCallWithObject("ValidateUser/ValidateUser", login, "Post");
                var result = JsonConvert.DeserializeObject<loginValidator>(value);

                //if (string.IsNullOrEmpty(result.Secret))
                //{
                //    var req = _2FA.GenerateSecret();
                //    result.Secret = req;

                //    var request = await ApiCall.ApiCallWithObject("/Login/saveSecret", result,"Post");
                //    if (request =="true")
                //    {
                //        return GetQR();
                //    }
                //    else
                //    {
                //        return RedirectToAction("Index", "Login", new { msg = "Invalid Authenticator Secret Key" });

                //    }
                //}



                if (result.status == 200)
                {
                    HttpContext.Session.SetString("TokenNo", result.tokenNo);
                    HttpContext.Session.SetString("UserName", result.UserName);
                    HttpContext.Session.SetString("Role", result.Role);
            
                    //var claims = new List<Claim> 
                    //        {
                    //            new Claim(ClaimTypes.Name, result.UserName),
                    //            new Claim(ClaimTypes.Authentication, result.tokenNo),
                    //            new Claim(ClaimTypes.Role,result.Role),
                    //            new Claim(ClaimTypes.Hash,result.Secret)
                    //        };

                    //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //var authProperties = new AuthenticationProperties
                    //{
                    //    /*  If IsPersistent is set to true, the authentication cookie will persist even after the browser is closed. 
                    //        If it's false, the authentication cookie will be deleted when the browser is closed.
                    //        This is often used to implement "Remember Me" functionality in login forms.*/
                    //    IsPersistent = true
                    //};

                    //await HttpContext.SignInAsync(
                    //    CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(claimsIdentity),
                    //    authProperties);

                    //ViewBag.UserName = result.UserName;
                    //TempData["UserName"] = result.UserName;
                    return Ok(value);
                }
                else
                {
                    return Ok("400");
                    //return RedirectToAction("Index", "Login", new { msg = "Invalid Credentials" });

                    //return RedirectToAction("ErrorPage", "Customer");
                }
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult LogOut([FromBody] string abc)
        {
            var token = HttpContext.Session.GetString("TokenNo");
            if (token != null)
            {
                HttpContext.Session.Remove("TokenNo");
                return Ok("Success");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> VerifyAdmin([FromBody] Login login)
        {
            try
            {
                var value = await ApiCall.ApiCallWithObject("ValidateUser/ValidateAdmin", login, "Post");
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


