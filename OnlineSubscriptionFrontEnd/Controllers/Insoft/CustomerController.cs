﻿using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.Insoft;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerSubscription()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertUpdateCustomer([FromBody] Customer ai)
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo == null)
                {
                    return Ok("-21");
                }
                ai.TokenNo = tokenNo;
                var result = await ApiCall.ApiCallWithObject("Customer/InsertUpdateCustomer", ai, "Post");
                return Ok(result);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.ToString();
                return RedirectToAction("Index", "UnexpectedError");
            }
        }





        [HttpPost]
        public async Task<IActionResult> getCustomers()
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
                    string i = await ApiCall.ApiCallWithString("Customer/getCustomers", TokenNo, "Post");
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
        public async Task<IActionResult> getCustomerByProductId([FromBody] Customer p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getCustomerByProductId", p, "Post");
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
        public async Task<IActionResult> getCustomerById([FromBody] Customer p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getCustomerById", p, "Post");
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
        public async Task<IActionResult> getSubsbyCusandProductId([FromBody] CustomerwiseModules p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getSubsbyCusandProductId", p, "Post");
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
        public async Task<IActionResult> getCustomerByAgentId([FromBody] Customer p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getCustomerByAgentId", p, "Post");
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
        public async Task<IActionResult> DeleteCustomer([FromBody] Customer p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/DeleteCustomer", p, "Post");
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



    }
}