using System;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models;
using mitt_news.Models.InputModels;
using mitt_news.Models.ViewModels;

namespace mitt_news.Controllers
{
    public class AdvertisementsController : Controller
    {
        private ApplicationDbContext DbContext { get; set; }

        public AdvertisementsController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        [HttpGet]
        public IActionResult NewAd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewAd(NewAdvertisementInputModel inputModel)
        {

            Advertisement advert = new Advertisement(
                inputModel.Title, inputModel.Company, inputModel.ContactName,
                inputModel.Category, inputModel.ContactNumber,
                inputModel.Description,inputModel.FrequencyPerHour
            );

            // save article to a database
            DbContext.Advertisements.Add(advert);

            await DbContext.SaveChangesAsync();

            return Redirect($"~/advertisements/details/{advert.Id}");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Advertisement advert = await DbContext.Advertisements.FindAsync(id);

            if(advert != null)
            {
                AdvertisementViewModel viewModel = new AdvertisementViewModel() 
                {
                    Title = advert.Title,
                    Company = advert.Company,
                    Description = advert.Description,
                    Category = advert.Category,
                    ContactName = advert.ContactName,
                    ContactNumber = advert.ContactNumber,
                    FrequencyPerHour = advert.FrequencyPerHour
                };
                return View(viewModel);
            }
            return Redirect("/home");
        }

    }
}

