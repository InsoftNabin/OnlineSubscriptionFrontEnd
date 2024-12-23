using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OnlineSubscriptionFrontEnd.Classes;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class DashboardController : Controller
    {
        public IActionResult IndexforDashboard()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }


        public async Task<ActionResult> AgentDashboard()
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
    }
}
