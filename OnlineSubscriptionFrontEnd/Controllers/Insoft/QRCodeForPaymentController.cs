using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.FonePay;
using OnlineSubscriptionFrontEnd.Models.Insoft;
using System.Data;
using System.Text;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class QRCodeForPaymentController : Controller
    {
        public IActionResult Index()
        {
            string tokenNo = HttpContext.Session.GetString("TokenNo");

            if (tokenNo == null)
            {
                return RedirectToAction("Index", "Login", new { msg = "sessionExpired" });
            }
            else {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> FonePayProceed([FromBody] FonePayRequest fpr1)
        {
            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }

                string data = await ApiCall.ApiCallWithObject("/QRCodeForPayment/GetFonePayDetails1", TokenNo, "Post");
                string unescapedData = JsonConvert.DeserializeObject<string>(data);
                var fpluList = JsonConvert.DeserializeObject<List<FonepayLookup>>(unescapedData);

                FonepayLookup fplu = fpluList.FirstOrDefault();

                FonePayRequest fpr = new FonePayRequest
                {
                    amount = fpr1.amount,
                    Remarks1 = fpr1.Remarks1,
                    Remarks2 = fpr1.Remarks2,
                    merchantCode = fplu.FonepayMerchantCode,
                    SecretKey = fplu.FonePaySecurityCode,
                    prn = Guid.NewGuid().ToString(),
                    username = fplu.FonePayUserName,
                    password = fplu.FonePayPassword,
                    Purpose = fpr1.Purpose
                };

                string reqData = await ApiCall.FonePayApiCallWithObject("/DynamicQR/GetQrCode", fpr, "Post");
                if (reqData=="Null")
                {
                    return Ok(new { status = "error", message = "Received null or empty response from FonePay API." });

                }
                else
                {
                    var response = JsonConvert.DeserializeObject<List<FonePayResponse>>(reqData);
                    var responseData = response.FirstOrDefault();


                    if (responseData != null)
                    {
                        responseData.prn = fpr.prn;
                    }

                    return Ok(responseData);
                }
            }
            catch (Exception ex)
            {
                return Ok("Exception: " + ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetPaymentStatus([FromBody] PaymentStatusRequest aa)
        {
            try
            {
                string TokenNo = HttpContext.Session.GetString("TokenNo");
                if (TokenNo == null)
                {
                    return Ok("-21");
                }
                string refererUrl = HttpContext.Request.Headers["Referer"];

                if (!string.IsNullOrEmpty(refererUrl))
                {
                    HttpContext.Session.SetString("RefererUrl", refererUrl);
                }

                string data = await ApiCall.ApiCallWithObject("/QRCodeForPayment/GetFonePayDetails1", TokenNo, "Post");
                string unescapedData = JsonConvert.DeserializeObject<string>(data);

                var fpluList = JsonConvert.DeserializeObject<List<FonepayLookup>>(unescapedData);
                FonepayLookup fplu = fpluList.FirstOrDefault();

                if (fplu == null)
                {
                    return Ok("-22"); 
                }
               

                PaymentStatusRequest fpr = new PaymentStatusRequest()
                {
                    merchantCode = fplu.FonepayMerchantCode,
                    prn = aa.prn,    
                    username=fplu.FonePayUserName,
                    password=fplu.FonePayPassword,
                   qrHashKey=aa.qrHashKey
                };

                string reqData = await ApiCall.FonePayApiCallWithObject("/DynamicQR/GetPaymentStatus", fpr, "Post");

                return Ok(reqData);
            }
            catch (Exception e)
            {
                
                return StatusCode(500, "Internal server error: " + e.Message);
            }
        }


    }
}


