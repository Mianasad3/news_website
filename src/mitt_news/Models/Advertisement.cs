using System;
namespace mitt_news.Models
{
    public enum AdvertisementCategories
    {
        Educational,
        Sports,
        Apparel
    }

    public class Advertisement
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int FrequencyPerHour { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public string ContactName { get; set; }
        public int ContactNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Advertisement(
            string title,
            string company,
            string contactName,
            string category,
            int contactNumber,
            string description,
            int frequencyPerHour
        ) {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Company = company;
            ContactName = contactName;
            CreatedAt = DateTime.Now;
            ContactNumber = contactNumber;
            Description = description;
            FrequencyPerHour = frequencyPerHour;

            if (category == "0")
            {
                Category = AdvertisementCategories.Apparel.ToString();
            }
            else if (category == "1")
            {
                Category = AdvertisementCategories.Sports.ToString();
            }
            else if (category == "2")
            {
                Category = AdvertisementCategories.Educational.ToString();
            }
        }
    }

}
