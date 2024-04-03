using Microsoft.AspNetCore.Identity;

namespace RateAucProfessors.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        // relations
    }
}
