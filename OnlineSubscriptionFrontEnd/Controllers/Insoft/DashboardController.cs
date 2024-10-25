using Microsoft.AspNetCore.Mvc;

namespace OnlineSubscriptionFrontEnd.Controllers.Insoft
{
    public class DashboardController : Controller
    {
        public IActionResult IndexforDashboard()
        {
            return View();
        }
    }
}
