using System;
namespace mitt_news.Models
{
    public enum Categories
    {
        Campus,
        International,
        Sports
    }

    public class Article
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Category { get; set; }

        public Article(string author, string title, string content, string category)
        {
            Id = Guid.NewGuid().ToString();
            Author = author;
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now;

            if (category == "0")
            {
                Category = Categories.Campus.ToString();
            }
            else if (category == "1")
            {
                Category = Categories.International.ToString();
            }
            else if (category == "2")
            {
                Category = Categories.Sports.ToString();
            }
        }
    }
}

