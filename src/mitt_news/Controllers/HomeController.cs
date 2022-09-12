using Microsoft.AspNetCore.Mvc;
using mitt_news.Models.ViewModels.Home;

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

        public IActionResult About()
        {
            AboutViewModel viewModel = new AboutViewModel()
            {
                Content = "Just some random content",
                Address = "130 Henlow Bay, Winnipeg, MB"
            };

            return View(viewModel);
        }

        public IActionResult Contact()
        {
            ContactViewModel viewModel = new ContactViewModel()
            {
                Content = "Another random content",
                StreetNumber = "130",
                StreetName = "Henlow Bay",
                City = "Winnipeg",
                Province = "MB"
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}