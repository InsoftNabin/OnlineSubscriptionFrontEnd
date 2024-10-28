using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.Insoft;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class SubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CustomerandSubscription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdateSubscription([FromBody] Subscription ai)
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo == null)
                {
                    return Ok("-21");
                }
                ai.TokenNo = tokenNo;
                var result = await ApiCall.ApiCallWithObject("Subscription/InsertUpdateSubscription", ai, "Post");
                return Ok(result);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.ToString();
                return RedirectToAction("Index", "UnexpectedError");
            }
        }





        [HttpPost]
        public async Task<IActionResult> getSubscription()
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
                    string i = await ApiCall.ApiCallWithString("Subscription/getSubscription", TokenNo, "Post");
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
        public async Task<IActionResult> getSubscriptionById([FromBody] Subscription p)
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
                    string i = await ApiCall.ApiCallWithObject("Subscription/getSubscriptionById", p, "Post");
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
        public async Task<IActionResult> DeleteSubscription([FromBody] Subscription p)
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
                    string i = await ApiCall.ApiCallWithObject("Subscription/DeleteSubscription", p, "Post");
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

