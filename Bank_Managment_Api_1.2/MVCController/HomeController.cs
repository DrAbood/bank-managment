using Microsoft.AspNetCore.Mvc;

namespace HomeController.MVCControllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Looks for Views/Home/Index.cshtml
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Errors")]
        public IActionResult Errors()
        {
            return View();
        }
    }
}
