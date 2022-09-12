using System;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models.InputModels;
using mitt_news.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using mitt_news.Models.ViewModels.Articles;

namespace mitt_news.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext DbContext { get; set; }

        public ArticlesController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public IActionResult New()
        {
            return View();
        }

        // Edit Page

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(string id)
        {
            Article article = await DbContext.Articles.FindAsync(id);
            if (article != null)
            {
                EditArticleViewModel editViewModel = new EditArticleViewModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Author = article.Author,
                    Content = article.Content,
                    Category = article.Category
                };
                return View(editViewModel);
            }
            return Redirect("/home");

        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(EditArticleInputModel inputModel, string id)
        {
            Article article = await DbContext.Articles.FindAsync(id);

            if (article != null)
            {
                article.Title = inputModel.Title;
                article.Author = inputModel.Author;
                article.Content = inputModel.Content;
                article.Category = inputModel.Category;

                await DbContext.SaveChangesAsync();

                return Redirect($"/articles/details/{article.Id}");
            }
            return Redirect("/home");
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> New(NewArticleInputModel inputModel)
        {
            Article article = new Article(
                inputModel.Author,
                inputModel.Title,
                inputModel.Content,
                inputModel.Category
            );

            if (inputModel.Content != null)
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
                    Id = article.Id,
                    Title = article.Title,
                    Author = article.Author,
                    Content = article.Content,
                    Category = article.Category
                };

                return View(viewModel);
            }

            return Redirect("/home");
        }
    }
}

