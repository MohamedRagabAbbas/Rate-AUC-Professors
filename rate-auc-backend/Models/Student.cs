using Microsoft.AspNetCore.Identity;

namespace RateAucProfessors.Models
{
    public class Student : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Standing { get; set; } = string.Empty;
        public string GraduationYear { get; set; } = string.Empty;
    }
}
