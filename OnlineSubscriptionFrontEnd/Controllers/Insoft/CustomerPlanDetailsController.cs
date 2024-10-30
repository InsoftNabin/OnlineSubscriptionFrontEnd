using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models.Insoft;
using OnlineSubscriptionFrontEnd.Classes;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class CustomerPlanDetailsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> InsertUpdate([FromBody] CustomerPlan customerModules)
        {


            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }

                customerModules.TokenNo = TokenNo;

                string affectedRows = await ApiCall.ApiCallWithObject("CustomerPlanDetails/InsertUpdate", customerModules, "Post");

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

        [HttpPost]
        public async Task<IActionResult> getSubscriptionLogByCustandprodId([FromBody] CustomerPlan p)
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
                    string i = await ApiCall.ApiCallWithObject("Subscription/getSubscriptionLogByCustandprodId", p, "Post");
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
        public async Task<IActionResult> getCurrentPlan([FromBody] CustomerPlan p)
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
                    string i = await ApiCall.ApiCallWithObject("CustomerPlanDetails/getCurrentPlan", p, "Post");
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
        public async Task<IActionResult> getCustomerSelectedPlansOnly([FromBody] Subscription p)
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
                    string i = await ApiCall.ApiCallWithObject("CustomerPlanDetails/getCustomerSelectedPlansOnly", p, "Post");
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
