using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.Insoft;
using QRCoder;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            string tokenNo = HttpContext.Session.GetString("TokenNo");

            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
                return View();
            }
        }
        public IActionResult CustomerSubscription()
        {
            string tokenNo = HttpContext.Session.GetString("TokenNo");
            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
                return View();
            }
        }


        public IActionResult Keysetup()
        {
            string tokenNo = HttpContext.Session.GetString("TokenNo");
            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
                return View();
            }
        }



        public IActionResult KeySearch()
        {
            string tokenNo = HttpContext.Session.GetString("TokenNo");
            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
                return View();
            }
        }
        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Keysearchsetup()
        {
            string tokenNo = HttpContext.Session.GetString("TokenNo");
            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else
            {
                ViewBag.Role = HttpContext.Session.GetString("Role");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateCustomer([FromBody] Customer ai)
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                //string AddedBy = HttpContext.Session.GetString("UserName");
                if (tokenNo == null)
                {
                    return Ok("-21");
                }
                ai.TokenNo = tokenNo;
                //ai.AddedBy = AddedBy;
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
        public async Task<IActionResult> getCountries()
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
                    string i = await ApiCall.ApiCallWithString("Customer/getCountries", TokenNo, "Post");
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
        public async Task<IActionResult> getCustomers([FromBody] string abc)
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
        public async Task<IActionResult> getCustSubsc([FromBody] Customer p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getCustSubsc", p, "Post");
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
        public async Task<IActionResult> getSubsbyCusandProductIdAdminInsoft([FromBody] CustomerwiseModules p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getSubsbyCusandProductIdAdminInsoft", p, "Post");
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
        public async Task<IActionResult> getSubsbyCusandProductIdAdmin([FromBody] CustomerwiseModules p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getSubsbyCusandProductIdAdmin", p, "Post");
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
        public async Task<IActionResult> getCustomerByAgentandProductId([FromBody] Customer p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getCustomerByAgentandProductId", p, "Post");
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
        public async Task<IActionResult> getSubsbyCusandProductIdWithUnpaidType([FromBody] CustomerwiseModules p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getSubsbyCusandProductIdWithUnpaidType", p, "Post");
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
        public async Task<IActionResult> getSubsbyCusandProductIdWithUnpaidTypeforAgent([FromBody] CustomerwiseModules p)
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
                    string i = await ApiCall.ApiCallWithObject("Customer/getSubsbyCusandProductIdWithUnpaidTypeforAgent", p, "Post");
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
