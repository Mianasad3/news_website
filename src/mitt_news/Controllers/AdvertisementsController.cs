using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models;
using mitt_news.Models.InputModels;
using mitt_news.Models.ViewModels.Advertisements;

namespace mitt_news.Controllers
{
    public class AdvertisementsController : Controller
    {
        private ApplicationDbContext DbContext { get; set; }

        public AdvertisementsController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet, Authorize(Roles = "MarketingManager")]
        public async Task<IActionResult> EditAd(string id)
        {
            Advertisement advert = await DbContext.Advertisements.FindAsync(id);

            if (advert != null)
            {
                EditAdvertisementViewModel viewModel = new EditAdvertisementViewModel()
                {
                    Id = advert.Id,
                    Title = advert.Title,
                    Company = advert.Company,
                    Description = advert.Description,
                    Category = advert.Category,
                    ContactNumber = advert.ContactNumber
                };

                return View(viewModel);
            }

            return Redirect("/home");
        }

        [HttpPost, Authorize(Roles = "MarketingManager")]
        public async Task<IActionResult> EditAd(string id, EditAdvertisementViewModel inputModel)
        {
            Advertisement advert = await DbContext.Advertisements.FindAsync(id);

            if (advert != null)
            {
                advert.Title = inputModel.Title;
                advert.Company = inputModel.Company;
                advert.Description = inputModel.Description;
                advert.ContactNumber = inputModel.ContactNumber;

                await DbContext.SaveChangesAsync();

                return Redirect($"/advertisements/details/{advert.Id}");
            }

            return Redirect("/home");
        }

        [HttpGet, Authorize(Roles = "MarketingManager")]
        public IActionResult NewAd()
        {
            return View();
        }

        [HttpPost, Authorize(Roles = "MarketingManager")]
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
                    Id = advert.Id,
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

