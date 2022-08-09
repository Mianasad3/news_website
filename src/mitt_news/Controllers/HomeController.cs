using Microsoft.AspNetCore.Mvc;

namespace mitt_news.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}