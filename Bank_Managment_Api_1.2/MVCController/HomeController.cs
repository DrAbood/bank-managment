using Microsoft.AspNetCore.Mvc;

namespace HomeController.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Looks for Views/Home/Index.cshtml
        }
        public IActionResult Privacy()
        {
            return View();;
        }
    }
}
