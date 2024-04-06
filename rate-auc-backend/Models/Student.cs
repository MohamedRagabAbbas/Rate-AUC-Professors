using Microsoft.AspNetCore.Identity;

namespace RateAucProfessors.Models
{
    public class Student : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
