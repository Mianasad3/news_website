﻿using System;
namespace mitt_news.Models.ViewModels.Advertisements
{
    public class AdvertisementViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string ContactName { get; set; }

        public int ContactNumber { get; set; }

        public int FrequencyPerHour { get; set; }
    }
}
