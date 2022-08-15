using System;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models.InputModels;
using mitt_news.Models;

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
                Article articleFromUserData = new Article(userData.Author, userData.Title);

                if(userData.Content != null)
            {
                articleFromUserData.Content = userData.Content;
            }

                


                // save article to database

                return View("ArticleCreated", articleFromUserData);   
            
        }


    }
}

