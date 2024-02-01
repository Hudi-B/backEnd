using Microsoft.AspNetCore.Identity;

namespace Auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
        public int Age { get; set; }
    }
}
