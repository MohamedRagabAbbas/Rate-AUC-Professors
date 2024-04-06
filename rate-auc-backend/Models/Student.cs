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

        // Relationship

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Feed>? Feeds { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reply>? Replys { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }

    }
}
