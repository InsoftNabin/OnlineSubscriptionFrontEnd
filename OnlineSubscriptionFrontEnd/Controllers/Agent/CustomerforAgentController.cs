using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

                if (tokenNo == null)
                {
                    return Ok("-21");  
                }
                else
                {
                    string responseAgent = await ApiCall.ApiCallWithString("/Customer/getAgentIdwithToken", tokenNo, "Post");
                    var parsedResponse = JsonConvert.DeserializeObject<string>(responseAgent);
                    var agentArray = JsonConvert.DeserializeObject<JArray>(parsedResponse);

                    if (agentArray != null && agentArray.Count > 0)
                    {
                        var agentId = agentArray[0]["AgentId"]?.ToString();
                        var agentName = agentArray[0]["Name"]?.ToString();


                        if (!string.IsNullOrEmpty(agentId))
                        {
                            ViewBag.AgentId = agentId;
                            ViewBag.AgentName = agentName;
                           HttpContext.Session.SetString("AgentId", agentId);

                            return View();
                        }
                        else
                        {
                            return RedirectToAction("ErrorPage", "Customer");
                        }
                    }
                    else
                    {
                        return RedirectToAction("ErrorPage", "Customer");
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public IActionResult SubscriptionExtensionByAgent()
        {
            string AgentId = HttpContext.Session.GetString("AgentId");
            ViewBag.AgentId = AgentId;
            return View();
        }



    }
}
