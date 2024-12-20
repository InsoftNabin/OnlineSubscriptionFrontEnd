
using Microsoft.AspNetCore.Mvc;
using OnlineSubscriptionFrontEnd.Classes;
using OnlineSubscriptionFrontEnd.Models.Agent;
using OnlineSubscriptionFrontEnd.Models.Insoft;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Role = HttpContext.Session.GetString("Role");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUpdate([FromBody] Agents ai)
        {
            try
            {
                string tokenNo = HttpContext.Session.GetString("TokenNo");
                if (tokenNo == null)
                {
                    return Ok("-21");
                }
                ai.TokenNo = tokenNo;
                var result = await ApiCall.ApiCallWithObject("Agent/InsertUpdate", ai, "Post");
                return Ok(result);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.ToString();
                return RedirectToAction("Index", "UnexpectedError");
            }
        }

        [HttpPost]
        public async Task<IActionResult> getAgents()
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
                    string i = await ApiCall.ApiCallWithString("Agent/getAgents", TokenNo, "Post");
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
        public async Task<IActionResult> getAgent([FromBody] Agents p)
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
                    string i = await ApiCall.ApiCallWithObject("Agent/getAgent", p, "Post");
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
        public async Task<IActionResult> DeleteAgent([FromBody] Agents p)
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
                    string i = await ApiCall.ApiCallWithObject("Agent/DeleteAgent", p, "Post");
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
