using System;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models.InputModels;

namespace mitt_news.Controllers
{
    public class ArticlesController : Controller
    {
        [HttpGet]

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]

        public IActionResult New(NewArticleInputModel userData)
        {
            return View();
        }
    }
}

