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
            return View();
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
                
                
                //FonepayLookup fl = JsonConvert.DeserializeObject<FonepayLookup>(data);
                //List<FonepayLookup> fpluList = JsonConvert.DeserializeObject<List<FonepayLookup>>(data);
               
                
                FonepayLookup fplu = fpluList.FirstOrDefault();

                FonePayRequest fpr = new FonePayRequest
                {
                    amount = fpr1.amount,
                    Remarks1 = fpr1.Remarks1,
                    Remarks2 = fpr1.Remarks2,
                    merchantCode = fplu.FonepayMerchantCode,
                    SecretKey = fplu.FonePaySecurityCode,
                    prn = "8bdac3ac-5071-46b3-bd41-a20c180c08c9",//new Guid().ToString(),
                    username = fplu.FonePayUserName,
                    password = fplu.FonePayPassword,
                    Purpose = fpr1.Purpose
                };

                string reqData = await ApiCall.FonePayApiCallWithObject("/DynamicQR/GetQrCode", fpr,"Post");

                return Ok(reqData);

            }
            catch (Exception ex)
            {
                return Ok("Exception: " + ex.ToString());
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> GetPaymentStatus()
        //{
        //    try
        //    {
        //        string TokenNo = HttpContext.Session.GetString("TokenNo");
        //        if (TokenNo == null)
        //        {
        //            return Ok("-21");
        //        }
        //        string data = await ApiCall.ApiCallWithObject("/QRCodeForPayment/GetFonePayDetails1", TokenNo, "Post");
        //        string unescapedData = JsonConvert.DeserializeObject<string>(data);
        //        var fpluList = JsonConvert.DeserializeObject<List<FonepayLookup>>(unescapedData);


        //        FonepayLookup fplu = fpluList.FirstOrDefault();

        //        PaymentStatusResponse fpr = new PaymentStatusResponse()
        //        {

        //            merchantCode = fplu.FonepayMerchantCode,
        //            prn = "8bdac3ac-5071-46b3-bd41-a20c180c08c9",//new Guid().ToString(),
        //            requestedAmount=  fpr.requestedAmount   ,
        //            totalTransactionAmount= fpr.totalTransactionAmount  
        //        };

        //        string reqData = await ApiCall.FonePayApiCallWithObject("/DynamicQR/GetPaymentStatus", fpr, "Post");

        //        return Ok(reqData);



        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }


        //}


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
                    prn = "8bdac3ac-5071-46b3-bd41-a20c180c08c9",
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


