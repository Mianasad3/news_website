using System;

namespace mitt_news.Models.InputModels
{
    public class NewArticleInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }
}

