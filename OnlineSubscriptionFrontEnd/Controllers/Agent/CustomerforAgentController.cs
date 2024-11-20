using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using DataService;

namespace OnlineSubscriptionFrontEnd.Controllers.Agent
{
    public class CustomerforAgentController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {

                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo==null)
                {
                    return Ok("-21");
                }
                else
                {
                    string responseAgent = await ApiCall.ApiCallWithString("//",tokenNo,"Post");
                    //ViewBag.AgentId= responseAgent.AgentId;
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IActionResult SubscriptionExtensionByAgent()
        {
            
            return View();
        }



    }
}
