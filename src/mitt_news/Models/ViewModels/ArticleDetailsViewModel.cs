using System;

namespace mitt_news.Models.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }
}
