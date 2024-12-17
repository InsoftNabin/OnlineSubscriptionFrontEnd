
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.Insoft;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class CustomerwiseModulesSelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AfterVerification(string recode)
        {               
            ViewBag.ukid = recode;
            return View("Index");
          
        }



        [HttpPost]
        public async Task<IActionResult> InsertUpdate([FromBody] CustomerwiseModules customerModules)
        {
          

            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }

                customerModules.TokenNo = TokenNo;

                string affectedRows = await ApiCall.ApiCallWithObject("CustomerwiseModulesSelection/InsertUpdate", customerModules, "Post");

                if (affectedRows != "Null")
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("NotSuccess");
                }
            }
            catch (Exception ex)
            {
                return Ok("Exception: " + ex.ToString());
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> InsertUpdate([FromBody] CustomerwiseModules customerModules)
        //{
        //    try
        //    {
        //        string TokenNo = HttpContext.Session.GetString("TokenNo");
        //        if (TokenNo == null)
        //        {
        //            return Ok("-21");
        //        }

        //        //foreach (var module in customerModules)
        //        //{
        //        customerModules.TokenNo = TokenNo; 

        //            string AffectedRows = await ApiCall.ApiCallWithObject("CustomerwiseModulesSelection/InsertUpdate", customerModules, "Post");

        //        //}

        //        return Ok("Success"); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok("Exception: " + ex.ToString());
        //    }
        //}



        [HttpPost]
        public async Task<IActionResult> getAllCustomerwiseModules()
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
                    string i = await ApiCall.ApiCallWithString("CustomerwiseModulesSelection/getAllCustomerwiseModules", TokenNo, "Post");
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


        [HttpPost]
        public async Task<IActionResult> getCustomerwiseModulesById([FromBody] CustomerwiseModules p)
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
                    p.TokenNo = TokenNo;
                    string i = await ApiCall.ApiCallWithObject("CustomerwiseModulesSelection/getCustomerwiseModulesById", p, "Post");
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



        //[HttpPost]
        //public async Task<IActionResult> DeleteCustomer([FromBody] CustomerwiseModules p)
        //{
        //    try
        //    {
        //        string TokenNo = HttpContext.Session.GetString("TokenNo");
        //        if (TokenNo == null)
        //        {
        //            return Ok("-21");
        //        }
        //        else
        //        {
        //            p.TokenNo = TokenNo;
        //            string i = await ApiCall.ApiCallWithObject("Customer/DeleteCustomer", p, "Post");
        //            return Ok(i);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string Exception = ex.ToString();
        //        TempData["Exception"] = Exception;
        //        return RedirectToAction("Index", "UnexpectedError");

        //    }
        //}



    }
}
