using Microsoft.AspNetCore.Mvc;


namespace TaskBoard.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Board");
            }

            return View();
        }
    }
}