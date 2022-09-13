using Microsoft.AspNetCore.Identity;

namespace mitt_news.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Department { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
