using System;
using Microsoft.AspNetCore.Mvc;
using mitt_news.Models;
using mitt_news.Models.InputModels;
using mitt_news.Models.ViewModels;

namespace mitt_news.Controllers
{
    public class AdvertisementsController : Controller
    {
        [HttpGet]
        public IActionResult NewAd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewAd(NewAdvertisementInputModel inputModel)
        {

            Advertisement advert = new Advertisement(
                inputModel.Title, inputModel.Company, inputModel.ContactName,
                inputModel.Category, inputModel.ContactNumber,
                inputModel.Description,inputModel.FrequencyPerHour
            );

            AdvertisementViewModel viewModel = new AdvertisementViewModel()
            {
                Title = advert.Title,
                Company = advert.Company,
                ContactName = advert.ContactName,
                Description = advert.Description,
                ContactNumber = advert.ContactNumber,
                Category = advert.Category,
                FrequencyPerHour = advert.FrequencyPerHour
            };

            return View("AdvertisementCreated", viewModel);
        }

    }
}

