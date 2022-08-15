using System;
namespace mitt_news.Models
{
    public enum Categories
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

        public Advertisement(string advertTitle,
            string company,
            string contactName,
            int category,
            int contactNumber,
            string discription,
            int freqPerHour
            )
        {
            Id = Guid.NewGuid().ToString();
            Title = advertTitle;
            Company = company;
            ContactName = contactName;
            CreatedAt = DateTime.Now;
            ContactNumber = contactNumber;
            Description = discription;
            FrequencyPerHour = freqPerHour;

            if (category == 0)
            {
                Category = Categories.Apparel.ToString();
            }
            else if (category == 1)
            {
                Category = Categories.Sports.ToString();
            }
            else if (category == 2)
            {
                Category = Categories.Educational.ToString();
            }

        }
    }

}
