using System;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models.InputModels;
using mitt_news.Models;
using mitt_news.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace mitt_news.Controllers
{
    [Authorize(Roles = "Editor")]
    public class ArticlesController : Controller
    {
        private ApplicationDbContext DbContext { get; set; }

        public ArticlesController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(NewArticleInputModel inputModel)
        {
            Article article = new Article(
                inputModel.Author,
                inputModel.Title,
                inputModel.Content,
                inputModel.Category
            );

            if(inputModel.Content != null)
            {
                article.Content = inputModel.Content;
            }

            // save article to database
            DbContext.Articles.Add(article);

            await DbContext.SaveChangesAsync();

            return Redirect($"/articles/details/{article.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Article article = await DbContext.Articles.FindAsync(id);

            if (article != null)
            {
                ArticleDetailsViewModel viewModel = new ArticleDetailsViewModel()
                {
                    Title = article.Title,
                    Author = article.Author,
                    Content = article.Content
                };

                return View(viewModel);
            }

            return Redirect("/home");
        }
    }
}

