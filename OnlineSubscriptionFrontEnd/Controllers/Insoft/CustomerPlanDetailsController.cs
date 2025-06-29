using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Models.Insoft;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models;

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

        //[HttpPost]
        //public async Task<IActionResult> getSubscriptionLogByCustandprodId([FromBody] CustomerPlan p)
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
        //            string i = await ApiCall.ApiCallWithObject("Subscription/getSubscriptionLogByCustandprodId",p, "Post");
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


        [HttpPost]
        public async Task<IActionResult> InsertUpdateSerialkEY([FromBody] SerialKey sk)
        {
            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }
                string affectedRows = await ApiCall.ApiCallWithObject("Customer/InsertUpdateSerialkEY", sk, "Post");

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
        public async Task<IActionResult> DeleteSerialkEY([FromBody] SerialKey sk)
        {
            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }
                string affectedRows = await ApiCall.ApiCallWithObject("Customer/DeleteSerialKey", sk, "Post");

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
        public async Task<IActionResult> getSubscriptionLogByCustandprodId([FromBody] CustomerPlan abc)
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
                    abc.TokenNo = TokenNo;
                    string i = await ApiCall.ApiCallWithObject("Subscription/GetSubscriptionLogByCustandprodId", abc, "Post");
                    //string i = await ApiCall.ApiCallWithObject("Subscription/GetSubscriptionLogByCustandprodId", p, "Post");
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
        public async Task<IActionResult> GetSerialKeyLog([FromBody] CustomerPlan abc)
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
                    abc.TokenNo = TokenNo;
                    string i = await ApiCall.ApiCallWithObject("Subscription/GetSerialKeyLog", abc, "Post");
                    //string i = await ApiCall.ApiCallWithObject("Subscription/GetSubscriptionLogByCustandprodId", p, "Post");
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
        public async Task<IActionResult> GetCustomerbyskey([FromBody] SerialKey abc)
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
                    string i = await ApiCall.ApiCallWithObject("Subscription/Getcustomerbyskey", abc, "Post");
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
        public async Task<IActionResult> Getcustomerforserialkey([FromBody] SerialKey abc)
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
                    string i = await ApiCall.ApiCallWithObject("Subscription/Getcustomerforserialkey", abc, "Post");
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
        public async Task<IActionResult> GetVoucherEntryStatus([FromBody] CustomerPlan abc)
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
                    abc.TokenNo = TokenNo;
                    string i = await ApiCall.ApiCallWithObject("CustomerPlanDetails/GetVoucherEntryStatus", abc, "Post");
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
        public async Task<IActionResult> VerifyorRejectSubscription([FromBody] CustomerPlan p)
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
                    string i = await ApiCall.ApiCallWithObject("Subscription/VerifyorRejectSubscription", p, "Post");
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
